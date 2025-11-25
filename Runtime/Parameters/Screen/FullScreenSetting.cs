// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class FullScreenSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => UnityEngine.Screen.fullScreen;

		protected override void OnApply(bool value) => UnityEngine.Screen.fullScreen = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class FullScreenSetting
	{
		private const string FILE_NAME = nameof(FullScreenSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + SLASH + FILE_NAME;
	}
}