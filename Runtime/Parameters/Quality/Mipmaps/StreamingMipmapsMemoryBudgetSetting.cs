// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Mipmaps
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class StreamingMipmapsMemoryBudgetSetting : SettingsParameter<float>
	{
		private const string FILE_NAME = nameof(StreamingMipmapsMemoryBudgetSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + 
		                                 nameof(Quality) + SEPARATOR + 
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;

		public override float CurrentValue =>
			QualitySettings.streamingMipmapsMemoryBudget;

		protected override void OnApply(float value) =>
			QualitySettings.streamingMipmapsMemoryBudget = value;
	}
}