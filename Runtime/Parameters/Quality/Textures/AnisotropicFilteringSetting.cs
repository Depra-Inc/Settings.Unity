// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Textures
{
	public sealed partial class AnisotropicFilteringSetting : SettingsParameter<AnisotropicFiltering>
	{
		protected override string DefaultName => FILE_NAME;

		public override AnisotropicFiltering CurrentValue => QualitySettings.anisotropicFiltering;

		protected override void OnApply(AnisotropicFiltering value) => QualitySettings.anisotropicFiltering = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class AnisotropicFilteringSetting
	{
		private const string FILE_NAME = nameof(AnisotropicFilteringSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Textures) + SLASH + FILE_NAME;
	}
}