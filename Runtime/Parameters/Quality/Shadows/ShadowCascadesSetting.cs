// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.ComponentModel;
using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowCascadesSetting : SettingsParameter<ShadowCascadesSetting.ShadowCascades>
	{
		public override ShadowCascades CurrentValue => QualitySettings.shadowCascades switch
		{
			>= 4 => ShadowCascades.FOUR_CASCADES,
			>= 2 => ShadowCascades.TWO_CASCADES,
			_ => ShadowCascades.NO_CASCADES
		};

		protected override void OnApply(ShadowCascades value) => QualitySettings.shadowCascades = value switch
		{
			ShadowCascades.FOUR_CASCADES => 4,
			ShadowCascades.TWO_CASCADES => 2,
			_ => 0
		};

		public enum ShadowCascades
		{
			[Description("No Cascades")]
			NO_CASCADES,

			[Description("Two Cascades")]
			TWO_CASCADES,

			[Description("Four Cascades")]
			FOUR_CASCADES,
		}
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowCascadesSetting
	{
		private const string FILE_NAME = nameof(ShadowCascadesSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}