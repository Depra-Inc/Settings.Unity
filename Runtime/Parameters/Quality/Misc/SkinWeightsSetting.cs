using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Misc
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class SkinWeightsSetting : SettingsParameter<SkinWeights>
	{
		private const string FILE_NAME = nameof(SkinWeightsSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Misc) + SEPARATOR + FILE_NAME;

		public override SkinWeights CurrentValue =>
			QualitySettings.skinWeights;

		protected override void OnApply(SkinWeights value) =>
			QualitySettings.skinWeights = value;
	}
}