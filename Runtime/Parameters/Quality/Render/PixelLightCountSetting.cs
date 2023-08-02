// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Render
{
	public sealed partial class PixelLightCountSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min;

		public override int CurrentValue =>
			QualitySettings.pixelLightCount;

		protected override void OnApply(int value) =>
			QualitySettings.pixelLightCount = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class PixelLightCountSetting
	{
		private const string FILE_NAME = nameof(PixelLightCountSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Render) + SEPARATOR + FILE_NAME;
	}
}