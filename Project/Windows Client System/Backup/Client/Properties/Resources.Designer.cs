﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BinarySoftCo.ChatSystem.Parsian_Chat.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BinarySoftCo.ChatSystem.Parsian_Chat.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ParsianChat.
        /// </summary>
        internal static string ApplicationName {
            get {
                return ResourceManager.GetString("ApplicationName", resourceCulture);
            }
        }
        
        internal static System.Drawing.Icon Icon {
            get {
                object obj = ResourceManager.GetObject("Icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Login {
            get {
                object obj = ResourceManager.GetObject("Login", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Offline {
            get {
                object obj = ResourceManager.GetObject("Offline", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Online {
            get {
                object obj = ResourceManager.GetObject("Online", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Wait {
            get {
                object obj = ResourceManager.GetObject("Wait", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
