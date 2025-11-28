// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class FullScreenModeSetting : OptionSettingsParameter<FullScreenMode>
	{
		private const string FILE_NAME = nameof(FullScreenModeSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + "/" + FILE_NAME;

		public override FullScreenMode CurrentValue => UnityEngine.Screen.fullScreenMode;

		protected override FullScreenMode[] Choices { get; } =
		{
			FullScreenMode.ExclusiveFullScreen,
			FullScreenMode.FullScreenWindow,
			FullScreenMode.MaximizedWindow,
			FullScreenMode.Windowed
		};

		protected override void OnApply(FullScreenMode value) => UnityEngine.Screen.fullScreenMode = value;
		protected override string ToDisplayName(FullScreenMode value) => value.ToString();
	}
}