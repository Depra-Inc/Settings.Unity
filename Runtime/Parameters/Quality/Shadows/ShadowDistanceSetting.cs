// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowDistanceSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min;

		public override float CurrentValue => QualitySettings.shadowDistance;

		protected override void OnApply(float value) => QualitySettings.shadowDistance = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowDistanceSetting
	{
		private const string FILE_NAME = nameof(ShadowDistanceSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}