﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessageAnalyzerExecutionEngine.Tests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SampleData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SampleData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MessageAnalyzerExecutionEngine.Tests.SampleData", typeof(SampleData).Assembly);
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
        ///   Looks up a localized string similar to [
        ///    {
        ///        &quot;profile_pic&quot;: &quot;https://pbs.twimg.com/profile_images/1587852208/1968208-rikimaru_icon_normal.jpg&quot;,
        ///        &quot;text&quot;: &quot;@mae_dessie remember this post, this is during the hackaton in davao!&quot;,
        ///        &quot;profile_id&quot;: 388217388,
        ///        &quot;stream_id&quot;: 632529219742908416,
        ///        &quot;profile_name&quot;: &quot;obliviousanima&quot;,
        ///        &quot;time&quot;: &quot;Mon Oct 10 11:38:06 +0000 2011&quot;,
        ///        &quot;batch_id&quot;: 12345678911159
        ///    },
        ///    {
        ///        &quot;profile_pic&quot;: &quot;https://pbs.twimg.com/profile_images/1587852208/1968208-rik [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string request {
            get {
                return ResourceManager.GetString("request", resourceCulture);
            }
        }
    }
}
