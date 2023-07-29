using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.LevelOfDetail
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class LodCrossFadeSetting : SettingsParameter<bool>
	{
		private const string FILE_NAME = nameof(LodCrossFadeSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(LevelOfDetail) + SEPARATOR + FILE_NAME;

		public override bool CurrentValue =>
			QualitySettings.enableLODCrossFade;

		protected override void OnApply(bool value) =>
			QualitySettings.enableLODCrossFade = value;
	}
}