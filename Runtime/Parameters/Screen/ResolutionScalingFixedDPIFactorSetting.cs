using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Screen
{
	public sealed partial class ResolutionScalingFixedDPIFactorSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min = 0.01f;

		public override float CurrentValue =>
			QualitySettings.resolutionScalingFixedDPIFactor;

		protected override void OnApply(float value) =>
			QualitySettings.resolutionScalingFixedDPIFactor = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ResolutionScalingFixedDPIFactorSetting
	{
		private const string FILE_NAME = nameof(ResolutionScalingFixedDPIFactorSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(Screen) + SEPARATOR + FILE_NAME;
	}
}