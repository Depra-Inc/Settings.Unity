using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.LevelOfDetail
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class MaximumLodLevelSetting : SettingsParameter<int>
	{
		private const string FILE_NAME = nameof(MaximumLodLevelSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(LevelOfDetail) + SEPARATOR + FILE_NAME;

		[SerializeField] private int _min;
		[SerializeField] private int _max = 7;

		public override int CurrentValue =>
			QualitySettings.maximumLODLevel;

		protected override void OnApply(int value) =>
			QualitySettings.maximumLODLevel = Mathf.Clamp(value, _min, _max);
	}
}