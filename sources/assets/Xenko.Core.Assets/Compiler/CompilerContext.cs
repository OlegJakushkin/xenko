// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using Xenko.Core.Settings;

namespace Xenko.Core.Assets.Compiler
{
    /// <summary>
    /// The context used when compiling an asset in a Package.
    /// </summary>
    public class CompilerContext : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerContext"/> class.
        /// </summary>
        public CompilerContext()
        {
            Properties = new PropertyCollection();
            PackageProperties = PackageProfile.SettingsContainer.CreateSettingsProfile(false, null, false);
        }

        /// <summary>
        /// Properties passed on the command line.
        /// </summary>
        public Dictionary<string, string> OptionProperties { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Gets the attributes attached to this context.
        /// </summary>
        /// <value>The attributes.</value>
        public PropertyCollection Properties { get; private set; }

        public SettingsProfile PackageProperties { get; private set; }

        public CompilerContext Clone()
        {
            var context = (CompilerContext)MemberwiseClone();
            return context;
        }

        public void Dispose()
        {
            PackageProperties.Dispose();
        }
    }
}
