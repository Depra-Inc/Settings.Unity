// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Misc
{
	public sealed partial class SkinWeightsSetting : SettingsParameter<SkinWeights>
	{
		public override SkinWeights CurrentValue => QualitySettings.skinWeights;

		protected override void OnApply(SkinWeights value) => QualitySettings.skinWeights = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class SkinWeightsSetting
	{
		private const string FILE_NAME = nameof(SkinWeightsSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Misc) + SLASH + FILE_NAME;
	}
}