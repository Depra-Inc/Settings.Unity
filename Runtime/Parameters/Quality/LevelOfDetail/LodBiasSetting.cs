// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.LevelOfDetail
{
	public sealed partial class LodBiasSetting : SettingsParameter<float>
	{
		[Min(0f)] [SerializeField] private float _minValue = 0.01f;

		public override float CurrentValue => QualitySettings.lodBias;

		protected override void OnApply(float value) =>
			QualitySettings.lodBias = Mathf.Max(value, _minValue);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class LodBiasSetting
	{
		private const string FILE_NAME = nameof(LodBiasSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(LevelOfDetail) + SLASH + FILE_NAME;
	}
}