﻿using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Misc
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class SoftVegetationSetting : SettingsParameter<bool>
	{
		private const string FILE_NAME = nameof(SoftVegetationSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Misc) + SEPARATOR + FILE_NAME;

		public override bool CurrentValue =>
			QualitySettings.softVegetation;

		protected override void OnApply(bool value) =>
			QualitySettings.softVegetation = value;
	}
}