// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.View
{
	public sealed partial class ButtonSettingParameterView : SettingParameterView<bool>
	{
		[SerializeField] private Button _button;

		private void OnEnable() =>
			_button.onClick.AddListener(ApplyParameter);

		private void OnDisable() =>
			_button.onClick.RemoveListener(ApplyParameter);

		private void ApplyParameter() =>
			Parameter.Apply(!Parameter.CurrentValue);
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class ButtonSettingParameterView
	{
		private const string FILE_NAME = nameof(ButtonSettingParameterView);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(View) + SEPARATOR + FILE_NAME;
	}
}