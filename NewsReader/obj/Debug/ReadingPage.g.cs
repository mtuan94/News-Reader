﻿

#pragma checksum "D:\GoogleDrive\Primary\PROJECT\VisualStudio\NewsReader\NewsReader\ReadingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B48E7B32E03B9473D29E920C283814C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsReader
{
    partial class ReadingPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 31 "..\..\ReadingPage.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).NavigationCompleted += this.WebView_NavigationCompleted;
                 #line default
                 #line hidden
                #line 31 "..\..\ReadingPage.xaml"
                ((global::Windows.UI.Xaml.Controls.WebView)(target)).DOMContentLoaded += this.WebView_DOMContentLoaded;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


