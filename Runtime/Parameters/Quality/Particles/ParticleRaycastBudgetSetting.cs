// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Particles
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ParticleRaycastBudgetSetting : SettingsParameter<int>
	{
		public override int CurrentValue => QualitySettings.particleRaycastBudget;

		protected override void OnApply(int value) => QualitySettings.particleRaycastBudget = value;
	}

	public sealed partial class ParticleRaycastBudgetSetting
	{
		private const string FILE_NAME = nameof(ParticleRaycastBudgetSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Particles) + SLASH + FILE_NAME;
	}
}