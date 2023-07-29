// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Textures
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class AnisotropicFilteringSetting : SettingsParameter<AnisotropicFiltering>
	{
		private const string FILE_NAME = nameof(AnisotropicFilteringSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Textures) + SEPARATOR + FILE_NAME;

		protected override string DefaultName => FILE_NAME;

		public override AnisotropicFiltering CurrentValue =>
			QualitySettings.anisotropicFiltering;

		protected override void OnApply(AnisotropicFiltering value) =>
			QualitySettings.anisotropicFiltering = value;
	}
}