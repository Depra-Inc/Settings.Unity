// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Module;

namespace Depra.Settings.View
{
	public sealed partial class ButtonSettingParameterView : SettingParameterView<bool>
	{
		[SerializeField] private Button _button;

		private void OnEnable() => _button.onClick.AddListener(ApplyParameter);

		private void OnDisable() => _button.onClick.RemoveListener(ApplyParameter);

		private void ApplyParameter() => Parameter.Apply(!Parameter.CurrentValue);
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class ButtonSettingParameterView
	{
		private const string FILE_NAME = nameof(ButtonSettingParameterView);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(View) + SLASH + FILE_NAME;
	}
}