// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using TMPro;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.View
{
	public sealed partial class DropdownSettingParameterView : SettingParameterView<int>
	{
		[SerializeField] private TMP_Dropdown _dropdown;

		private void OnEnable()
		{
			UpdateDropdown(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateDropdown;
			_dropdown.onValueChanged.AddListener(ApplyParameter);
		}

		private void OnDisable()
		{
			Parameter.ValueChanged -= UpdateDropdown;
			_dropdown.onValueChanged.RemoveListener(ApplyParameter);
		}

		private void ApplyParameter(int value) =>
			Parameter.Apply(value);

		private void UpdateDropdown(int value)
		{
			if (value == _dropdown.value)
			{
				return;
			}

			_dropdown.SetValueWithoutNotify(value);
			_dropdown.RefreshShownValue();
		}
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class DropdownSettingParameterView
	{
		private const string FILE_NAME = nameof(DropdownSettingParameterView);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(View) + SEPARATOR + FILE_NAME;
	}
}