// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowResolutionSetting : SettingsParameter<ShadowResolution>
	{
		public override ShadowResolution CurrentValue => QualitySettings.shadowResolution;

		protected override void OnApply(ShadowResolution value) => QualitySettings.shadowResolution = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowResolutionSetting
	{
		private const string FILE_NAME = nameof(ShadowResolutionSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}