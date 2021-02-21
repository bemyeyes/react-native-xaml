#pragma once
#include <pch.h>
#include <functional>
#include <string>
#include <JSValue.h>
#include <JSValueReader.h>
#include <JSValueXaml.h>
#ifdef USE_WINMD_READER
#include <winmd_reader.h>
#endif
#include <winrt/Windows.Foundation.Collections.h>
#include <UI.Xaml.Media.h>
#include "Crc32Str.h"

using namespace xaml;
using namespace xaml::Controls;
using namespace winrt::Microsoft::ReactNative;

namespace winrt::Microsoft::ReactNative {
  inline void ReadValue(JSValue const& jsValue, xaml::Media::SolidColorBrush& value) noexcept {
    auto color = XamlHelper::ColorFrom([&jsValue](IJSValueWriter const& writer) noexcept { jsValue.WriteTo(writer); });
    value = xaml::Media::SolidColorBrush(color);
  }
}

enum class XamlPropType {
  Boolean,
  Int,
  Double,
  String,
  Object,
  Enum,
};

template <typename T> bool IsType(winrt::Windows::Foundation::IInspectable i) { return i.try_as<T>() != nullptr; }

template <typename T> winrt::IInspectable MakeEnum(const std::string& value) noexcept;

template<typename T, std::enable_if_t<std::is_enum<T>::value, int> = 0>
void SetPropValue (xaml::DependencyObject o, xaml::DependencyProperty prop, const winrt::Microsoft::ReactNative::JSValue& v) {
  auto str = v.AsString();
  auto valueEnum = MakeEnum<T>(str);
  o.SetValue(prop, winrt::box_value(valueEnum));
}


template<typename T, std::enable_if_t<!std::is_enum<T>::value && !std::is_same<winrt::hstring, T>::value, int> = 0>
void SetPropValue(xaml::DependencyObject o, xaml::DependencyProperty prop, const winrt::Microsoft::ReactNative::JSValue& v) {
  auto b = v.To<T>();
  o.SetValue(prop, winrt::box_value(b));
}

template<typename T, std::enable_if_t<std::is_same<T, winrt::hstring>::value, int> = 0>
void SetPropValue(xaml::DependencyObject o, xaml::DependencyProperty prop, const winrt::Microsoft::ReactNative::JSValue& v) {
  auto b = v.AsString();
  o.SetValue(prop, winrt::box_value(winrt::to_hstring(b)));
}



struct PropInfo {
  stringKey propName;
  
  using isType_t = bool (*) (winrt::Windows::Foundation::IInspectable);
  isType_t isType;
  
  using xamlPropertyGetter_t = xaml::DependencyProperty(*)();
  xamlPropertyGetter_t xamlPropertyGetter;

  using xamlPropertySetter_t = void (*) (xaml::DependencyObject, xaml::DependencyProperty, const winrt::Microsoft::ReactNative::JSValue&);
  xamlPropertySetter_t xamlPropertySetter;

  ViewManagerPropertyType jsType;

  void ClearValue(xaml::DependencyObject o) const {
    o.ClearValue(xamlPropertyGetter());
  }

  void SetValue(xaml::DependencyObject o, const winrt::Microsoft::ReactNative::JSValue& v) const {
    if (v.IsNull()) {
      o.ClearValue(xamlPropertyGetter());
    }
    else {
      xamlPropertySetter(o, xamlPropertyGetter(), v);
    }
  }
};

struct XamlMetadata {
  winrt::Windows::Foundation::IInspectable Create(const std::string& typeName, const winrt::Microsoft::ReactNative::IReactContext& context) const;
  XamlMetadata();
  const PropInfo* GetProp(const std::string& propertyName, const winrt::Windows::Foundation::IInspectable& obj) const;
  static winrt::Windows::Foundation::IInspectable ActivateInstance(const winrt::hstring& hstr);
  void PopulateNativeProps(winrt::Windows::Foundation::Collections::IMap<winrt::hstring, ViewManagerPropertyType>& nativeProps) const;

private:
  static const PropInfo xamlPropertyMap[];
  static const uint32_t xamlPropCount;
  mutable std::map<std::string, std::function<void(winrt::Windows::Foundation::IInspectable o, winrt::Microsoft::ReactNative::IReactContext context)> > xamlEventMap;
#ifdef USE_WINMD_READER
  std::unique_ptr<winmd::reader::cache> reader;
#endif
private:
  winrt::Windows::Foundation::IInspectable XamlMetadata::Create(const std::string& typeName) const;
};