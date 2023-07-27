using System;
using Depra.Settings.Unity.Runtime.Delegates;
using Depra.Settings.Unity.Runtime.Save;
using UnityEngine;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
    /// <summary>
    /// A class that all settings must inherit from.
    /// </summary>
    public abstract class SettingsParameter : ScriptableObject
    {
        public abstract string Name { get; }
        
        internal abstract string Key { get; }
        
        internal abstract Type ValueType { get; }
        
        internal abstract IPersistent Persistent { get; }
        
        internal abstract event SettingValueChangedDelegate ValueChangedRaw;
    }
}