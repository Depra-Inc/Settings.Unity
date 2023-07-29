// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Particles
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ParticleRaycastBudgetSetting : SettingsParameter<int>
	{
		private const string FILE_NAME = nameof(ParticleRaycastBudgetSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + 
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Particles) + SEPARATOR + FILE_NAME;

		public override int CurrentValue => 
			QualitySettings.particleRaycastBudget;

		protected override void OnApply(int value) => 
			QualitySettings.particleRaycastBudget = value;
	}
}