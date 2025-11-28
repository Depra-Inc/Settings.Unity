// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ResolutionSetting : OptionSettingsParameter<Resolution>
	{
		private const string FILE_NAME = "Resolution";
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + "/" + FILE_NAME;

		public override Resolution CurrentValue => UnityEngine.Screen.currentResolution;

		protected override Resolution[] Choices => UnityEngine.Screen.resolutions;

		protected override void OnApply(Resolution value) =>
			UnityEngine.Screen.SetResolution(value.width, value.height,
				UnityEngine.Screen.fullScreenMode, value.refreshRateRatio);

		protected override string ToDisplayName(Resolution value) => value.ToString();
	}
}