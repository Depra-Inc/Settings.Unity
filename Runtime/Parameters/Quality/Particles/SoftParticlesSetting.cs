// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Particles
{
	public sealed partial class SoftParticlesSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.softParticles;

		protected override void OnApply(bool value) => QualitySettings.softParticles = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class SoftParticlesSetting
	{
		private const string FILE_NAME = nameof(SoftParticlesSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Particles) + SLASH + FILE_NAME;
	}
}