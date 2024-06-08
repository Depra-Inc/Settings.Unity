// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.AntiAliasing
{
	public sealed partial class AntiAliasingSetting : SettingsParameter<AntiAliasingSetting.AAFilteringOption>
	{
		protected override string DefaultName => FILE_NAME;

		public override AAFilteringOption CurrentValue => (AAFilteringOption) QualitySettings.antiAliasing;

		protected override void OnApply(AAFilteringOption value) => QualitySettings.antiAliasing = (int) value;

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

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(AntiAliasing) + SLASH + FILE_NAME;
	}
}