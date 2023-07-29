// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.ComponentModel;
using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Shadows
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ShadowCascadesSetting : SettingsParameter<ShadowCascadesSetting.ShadowCascades>
	{
		private const string FILE_NAME = nameof(ShadowCascadesSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + 
		                                 nameof(Quality) + SEPARATOR + 
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;

		public override ShadowCascades CurrentValue =>
			QualitySettings.shadowCascades switch
			{
				>= 4 => ShadowCascades.FOUR_CASCADES,
				>= 2 => ShadowCascades.TWO_CASCADES,
				_ => ShadowCascades.NO_CASCADES
			};

		protected override void OnApply(ShadowCascades value)
		{
			QualitySettings.shadowCascades = value switch
			{
				ShadowCascades.FOUR_CASCADES => 4,
				ShadowCascades.TWO_CASCADES => 2,
				_ => 0
			};
		}
		
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
}