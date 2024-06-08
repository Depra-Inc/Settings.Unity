// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.LevelOfDetail
{
	public sealed partial class MaximumLodLevelSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min;
		[SerializeField] private int _max = 7;

		public override int CurrentValue => QualitySettings.maximumLODLevel;

		protected override void OnApply(int value) => QualitySettings.maximumLODLevel = Mathf.Clamp(value, _min, _max);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class MaximumLodLevelSetting
	{
		private const string FILE_NAME = nameof(MaximumLodLevelSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(LevelOfDetail) + SLASH + FILE_NAME;
	}
}