// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Misc
{
	public sealed partial class SoftVegetationSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.softVegetation;

		protected override void OnApply(bool value) => QualitySettings.softVegetation = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class SoftVegetationSetting
	{
		private const string FILE_NAME = nameof(SoftVegetationSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Misc) + SLASH + FILE_NAME;
	}
}