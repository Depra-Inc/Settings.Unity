// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.AntiAliasing
{
	public sealed partial class AntiAliasingSetting : SettingsParameter<AntiAliasingSetting.AAFilteringOption>
	{
		protected override string DefaultName => FILE_NAME;

		public override AAFilteringOption CurrentValue =>
			(AAFilteringOption) QualitySettings.antiAliasing;

		protected override void OnApply(AAFilteringOption value) =>
			QualitySettings.antiAliasing = (int) value;

		public enum AAFilteringOption
		{
			DISABLED,
			_2xMultiSampling,
			_4xMultiSampling,
			_8xMultiSampling,
		}
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class AntiAliasingSetting
	{
		private const string FILE_NAME = nameof(AntiAliasingSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(AntiAliasing) + SEPARATOR + FILE_NAME;
	}
}