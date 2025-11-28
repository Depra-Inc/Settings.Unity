// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class ResolutionScalingFixedDPIFactorSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min = 0.01f;

		public override float CurrentValue => QualitySettings.resolutionScalingFixedDPIFactor;

		protected override void OnApply(float value) =>
			QualitySettings.resolutionScalingFixedDPIFactor = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ResolutionScalingFixedDPIFactorSetting
	{
		private const string FILE_NAME = nameof(ResolutionScalingFixedDPIFactorSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + SLASH + FILE_NAME;
	}
}