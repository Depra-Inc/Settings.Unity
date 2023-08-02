// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using TMPro;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.View
{
	public sealed partial class SettingNameLabel : MonoBehaviour
	{
		[SerializeField] private TMP_Text _displayName;
		[SerializeField] private SettingsParameter _parameter;

		private void Start() => _displayName.text = _parameter.DisplayName;
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class SettingNameLabel
	{
		private const string FILE_NAME = nameof(SettingNameLabel);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(View) + SEPARATOR + FILE_NAME;
	}
}