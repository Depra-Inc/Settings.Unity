// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Mipmaps
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class StreamingMipmapsMaxLevelReductionSetting : SettingsParameter<int>
	{
		private const string FILE_NAME = nameof(StreamingMipmapsMaxLevelReductionSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + 
		                                 nameof(Quality) + SEPARATOR + 
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;

		public override int CurrentValue =>
			QualitySettings.streamingMipmapsMaxLevelReduction;

		protected override void OnApply(int value) =>
			QualitySettings.streamingMipmapsMaxLevelReduction = value;
	}
}