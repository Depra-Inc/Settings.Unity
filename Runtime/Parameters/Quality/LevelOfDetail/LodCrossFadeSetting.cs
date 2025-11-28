// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>
#if UNITY_2022_1_OR_NEWER
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.LevelOfDetail
{
	public sealed partial class LodCrossFadeSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.enableLODCrossFade;

		protected override void OnApply(bool value) => QualitySettings.enableLODCrossFade = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class LodCrossFadeSetting
	{
		private const string FILE_NAME = nameof(LodCrossFadeSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(LevelOfDetail) + SLASH + FILE_NAME;
	}
}
#endif