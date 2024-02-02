// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowNearPlaneOffsetSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min;

		public override float CurrentValue => QualitySettings.shadowNearPlaneOffset;

		protected override void OnApply(float value) => QualitySettings.shadowNearPlaneOffset = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowNearPlaneOffsetSetting
	{
		private const string FILE_NAME = nameof(ShadowNearPlaneOffsetSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}