using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;

namespace Depra.Settings.Unity.Runtime.View
{
    public abstract class SettingParameterView<TValue> : MonoBehaviour
    {
        [SerializeField] private SettingsParameter<TValue> _parameter;

        protected SettingsParameter<TValue> Parameter => _parameter;

        public virtual void Initialize() { }
    }
}