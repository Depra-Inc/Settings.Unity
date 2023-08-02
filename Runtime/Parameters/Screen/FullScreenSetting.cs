// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Screen
{
	public sealed partial class FullScreenSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue =>
			UnityEngine.Screen.fullScreen;

		protected override void OnApply(bool value) =>
			UnityEngine.Screen.fullScreen = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class FullScreenSetting
	{
		private const string FILE_NAME = nameof(FullScreenSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(Screen) + SEPARATOR + FILE_NAME;
	}
}