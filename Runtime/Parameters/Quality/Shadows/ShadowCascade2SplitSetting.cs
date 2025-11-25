// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowCascade2SplitSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min;
		[SerializeField] private float _max = 1f;

		public override float CurrentValue => QualitySettings.shadowCascade2Split;

		protected override void OnApply(float value) =>
			QualitySettings.shadowCascade2Split = Mathf.Clamp(value, _min, _max);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowCascade2SplitSetting
	{
		private const string FILE_NAME = nameof(ShadowCascade2SplitSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}