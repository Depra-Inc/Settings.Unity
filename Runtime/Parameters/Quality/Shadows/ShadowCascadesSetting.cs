﻿// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.ComponentModel;
using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Shadows
{
	public sealed partial class ShadowCascadesSetting : SettingsParameter<ShadowCascadesSetting.ShadowCascades>
	{
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

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowCascadesSetting
	{
		private const string FILE_NAME = nameof(ShadowCascadesSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;
	}
}