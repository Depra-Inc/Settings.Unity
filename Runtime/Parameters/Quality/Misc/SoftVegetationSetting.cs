using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Misc
{
	public sealed partial class SoftVegetationSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue =>
			QualitySettings.softVegetation;

		protected override void OnApply(bool value) =>
			QualitySettings.softVegetation = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class SoftVegetationSetting
	{
		private const string FILE_NAME = nameof(SoftVegetationSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Misc) + SEPARATOR + FILE_NAME;
	}
}