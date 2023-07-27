using TMPro;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.View
{
    [AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
    public sealed class DropdownSettingParameterView : SettingParameterView<int>
    {
        private const string FILE_NAME = nameof(DropdownSettingParameterView);
        private const string MENU_NAME = MODULE_PATH + "/" + nameof(View) + "/" + FILE_NAME;

        [SerializeField] private TMP_Dropdown _dropdown;
        
        private void OnEnable()
        {
            UpdateDropdown(Parameter.CurrentValue);
            
            Parameter.ValueChanged += UpdateDropdown;
            _dropdown.onValueChanged.AddListener(OnSettingValueChanged);
        }

        private void OnDisable()
        {
            Parameter.ValueChanged -= UpdateDropdown;
            _dropdown.onValueChanged.RemoveListener(OnSettingValueChanged);
        }

        private void UpdateDropdown(int value)
        {
            _dropdown.SetValueWithoutNotify(value);
            _dropdown.RefreshShownValue();
        }

        private void OnSettingValueChanged(int value) => Parameter.Apply(value);
    }
}