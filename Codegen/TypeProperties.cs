﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Codegen
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class TypeProperties : TypePropertiesBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("#pragma once\r\n#include \"pch.h\"\r\n#include \"XamlMetadata.h\"\r\n#include \"Crc32Str.h\"\r" +
                    "\n\r\n/*************************************************************\r\nTHIS FILE WAS" +
                    " AUTOMATICALLY GENERATED, DO NOT MODIFY MANUALLY\r\nSOURCE WINMDS USED:\r\n");

foreach (var winmd in WinMDs) {

            this.Write("  - ");
            this.Write(this.ToStringHelper.ToStringWithCulture(winmd));
            this.Write("\r\n");

}

            this.Write("**************************************************************/\r\n\r\n");
 foreach (var ns in Properties.Select(p => p.DeclaringType.GetNamespace()).Distinct()) { 
            this.Write("#include <winrt/");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(".h>\r\n");
 } 
            this.Write(@"
template<typename T> 
winrt::Windows::Foundation::IInspectable AsType(const winrt::Windows::Foundation::IInspectable& o) {
  return o.try_as<T>();
}

template<typename T> 
winrt::Windows::Foundation::IInspectable AsUnwrappedType(const winrt::Windows::Foundation::IInspectable& o) {
  return Unwrap<T>(o);
}

/*static*/ const PropInfo xamlPropertyMap[] = {
  ");
 foreach (var p in Properties) { 
            this.Write("      { MAKE_KEY(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.ToJsName(p)));
            this.Write("\"), ");
            this.Write(this.ToStringHelper.ToStringWithCulture((Util.DerivesFrom(p.DeclaringType, $"{XamlNames.XamlNamespace}.FrameworkElement") || p.DeclaringType.GetName() == "UIElement")  ? "AsType" : "AsUnwrappedType"));
            this.Write("<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetCppWinRTType(p.DeclaringType)));
            this.Write(">,  []() { return ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetCppWinRTType(p.Property != null ? p.Property.DeclaringType : p.DeclaringType)));
            this.Write("::");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.SimpleName));
            this.Write("Property(); }, SetPropValue<");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.PropertyType != null ? Util.GetCppWinRTType(p.PropertyType) : Util.GetCppWinRTType(p.Property.GetPropertyType())));
            this.Write(">, ViewManagerPropertyType::");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetVMPropertyType(p)));
            this.Write(" },\r\n  ");
 } 
            this.Write("};\r\n\r\n");
 foreach (var p in FakeProps) { 
            this.Write("void Set");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.GetName()));
            this.Write("_");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.DeclaringType.GetName()));
            this.Write("(const xaml::DependencyObject& o, const xaml::DependencyProperty&, const winrt::M" +
                    "icrosoft::ReactNative::JSValue& v, const winrt::Microsoft::ReactNative::IReactCo" +
                    "ntext& reactContext);\r\n");
 } 
            this.Write("\r\n");
 foreach (var p in SyntheticProps) { 
            this.Write("void Set");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Name));
            this.Write("_");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.DeclaringType.GetName()));
            this.Write("(const xaml::DependencyObject& o, const xaml::DependencyProperty&, const winrt::M" +
                    "icrosoft::ReactNative::JSValue& v, const winrt::Microsoft::ReactNative::IReactCo" +
                    "ntext& reactContext);\r\n");
 } 
            this.Write("\r\n/*static*/ const PropInfo fakeProps[] = {\r\n");
 foreach (var p in FakeProps) { 
            this.Write("    { MAKE_KEY(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.ToJsName(p)));
            this.Write("\"), AsUnwrappedType<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetCppWinRTType(p.DeclaringType)));
            this.Write(">, nullptr, Set");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.GetName()));
            this.Write("_");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.DeclaringType.GetName()));
            this.Write(", ViewManagerPropertyType::");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetVMPropertyType(p)));
            this.Write(" },\r\n");
 } 
 foreach (var p in SyntheticProps) { 
            this.Write("    { MAKE_KEY(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.ToJsName(p.Name)));
            this.Write("\"), AsType<");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetCppWinRTType(p.DeclaringType)));
            this.Write(">, nullptr, Set");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Name));
            this.Write("_");
            this.Write(this.ToStringHelper.ToStringWithCulture(p.DeclaringType.GetName()));
            this.Write(", ViewManagerPropertyType::");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetVMPropertyType(p)));
            this.Write(" },\r\n");
 } 
            this.Write("\r\n};\r\n\r\n#ifdef USE_CRC32\r\nvoid XamlMetadata::PopulateNativeProps(winrt::Windows::" +
                    "Foundation::Collections::IMap<winrt::hstring, ViewManagerPropertyType>& nativePr" +
                    "ops) const {\r\n");
 foreach (var p in Properties.Distinct(new NameEqualityComparer())) { 
            this.Write("    nativeProps.Insert(winrt::to_hstring(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.ToJsName(p)));
            this.Write("\"), ViewManagerPropertyType::");
            this.Write(this.ToStringHelper.ToStringWithCulture(Util.GetVMPropertyType(p)));
            this.Write(");\r\n");
 } 
            this.Write(@"}
#else
void XamlMetadata::PopulateNativeProps(winrt::Windows::Foundation::Collections::IMap<winrt::hstring, ViewManagerPropertyType>& nativeProps) const {
  for (auto const& entry : xamlPropertyMap) {
    nativeProps.Insert(winrt::to_hstring(entry.propName), entry.jsType);
  }
  for (auto const& entry : fakeProps) {
    nativeProps.Insert(winrt::to_hstring(entry.propName), entry.jsType);
  }
}
#endif


struct XamlCommand {
    const char* name;
    void (*pfn)(FrameworkElement fe, const winrt::Microsoft::ReactNative::JSValueArray& args, const XamlMetadata& xaml) noexcept;
};

");
 foreach (var kv in Util.commands) { 
   foreach (var command in kv.Value) { 
            this.Write("void ");
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            this.Write("Command(FrameworkElement fe, const winrt::Microsoft::ReactNative::JSValueArray& /" +
                    "* args */, const XamlMetadata& xaml) noexcept;\r\n");
 } } 
            this.Write("\r\nconst XamlCommand xamlCommands[] = {\r\n");
 foreach (var kv in Util.commands) { 
   foreach (var command in kv.Value) { 
            this.Write("  { \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            this.Write("\", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(command.Name));
            this.Write("Command},\r\n");
   } 
 } 
            this.Write("};\r\n\r\nvoid XamlMetadata::PopulateCommands(const winrt::Windows::Foundation::Colle" +
                    "ctions::IVector<winrt::hstring>& commands) const {\r\n  for (auto const& entry : x" +
                    "amlCommands) {\r\n    commands.Append(winrt::to_hstring(entry.name));\r\n  }\r\n}\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class TypePropertiesBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        public System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
