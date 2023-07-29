// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.AntiAliasing
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class AntiAliasingSetting : SettingsParameter<AntiAliasingSetting.AAFilteringOption>
	{
		private const string FILE_NAME = nameof(AntiAliasingSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(AntiAliasing) + SEPARATOR + FILE_NAME;

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
}