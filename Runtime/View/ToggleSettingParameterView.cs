// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Module;

namespace Depra.Settings.Runtime.View
{
	public sealed partial class ToggleSettingParameterView : SettingParameterView<bool>
	{
		[SerializeField] private Toggle _toggle;

		private void OnEnable()
		{
			UpdateToggle(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateToggle;
			_toggle.onValueChanged.AddListener(ApplyParameter);
		}

		private void OnDisable()
		{
			Parameter.ValueChanged -= UpdateToggle;
			_toggle.onValueChanged.RemoveListener(ApplyParameter);
		}

		private void ApplyParameter(bool value) => Parameter.Apply(value);

		private void UpdateToggle(bool value)
		{
			if (value != _toggle.isOn)
			{
				_toggle.SetIsOnWithoutNotify(value);
			}
		}
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class ToggleSettingParameterView
	{
		private const string FILE_NAME = nameof(ToggleSettingParameterView);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(View) + SLASH + FILE_NAME;
	}
}