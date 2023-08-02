using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.LevelOfDetail
{
	public sealed partial class LodCrossFadeSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue =>
			QualitySettings.enableLODCrossFade;

		protected override void OnApply(bool value) =>
			QualitySettings.enableLODCrossFade = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class LodCrossFadeSetting
	{
		private const string FILE_NAME = nameof(LodCrossFadeSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(LevelOfDetail) + SEPARATOR + FILE_NAME;
	}
}