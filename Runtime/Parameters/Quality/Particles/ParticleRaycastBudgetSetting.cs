// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Particles
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ParticleRaycastBudgetSetting : SettingsParameter<int>
	{
		public override int CurrentValue =>
			QualitySettings.particleRaycastBudget;

		protected override void OnApply(int value) =>
			QualitySettings.particleRaycastBudget = value;
	}

	public sealed partial class ParticleRaycastBudgetSetting
	{
		private const string FILE_NAME = nameof(ParticleRaycastBudgetSetting);

		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Particles) + SEPARATOR + FILE_NAME;
	}
}