// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsMemoryBudgetSetting : SettingsParameter<float>
	{
		public override float CurrentValue => QualitySettings.streamingMipmapsMemoryBudget;

		protected override void OnApply(float value) => QualitySettings.streamingMipmapsMemoryBudget = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsMemoryBudgetSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsMemoryBudgetSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Mipmaps) + SLASH + FILE_NAME;
	}
}