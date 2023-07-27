using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.View
{
	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed class ToggleSettingParameterView : SettingParameterView<bool>
	{
		private const string FILE_NAME = nameof(ToggleSettingParameterView);
		private const string MENU_NAME = MODULE_PATH + "/" + nameof(View) + "/" + FILE_NAME;

		[SerializeField] private Toggle _toggle;
		
		private void OnEnable()
		{
			UpdateToggle(Parameter.CurrentValue);
			
			Parameter.ValueChanged += UpdateToggle;
			_toggle.onValueChanged.AddListener(OnSettingValueChanged);
		}

		private void OnDisable()
		{
			Parameter.ValueChanged -= UpdateToggle;
			_toggle.onValueChanged.RemoveListener(OnSettingValueChanged);
		}

		private void UpdateToggle(bool value) => _toggle.SetIsOnWithoutNotify(value);

		private void OnSettingValueChanged(bool value) => Parameter.Apply(value);
	}
}