using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Misc
{
	public sealed partial class SkinWeightsSetting : SettingsParameter<SkinWeights>
	{
		public override SkinWeights CurrentValue =>
			QualitySettings.skinWeights;

		protected override void OnApply(SkinWeights value) =>
			QualitySettings.skinWeights = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class SkinWeightsSetting
	{
		private const string FILE_NAME = nameof(SkinWeightsSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Misc) + SEPARATOR + FILE_NAME;
	}
}