// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Shadows
{
	public sealed partial class ShadowmaskModeSetting : SettingsParameter<ShadowmaskMode>
	{
		public override ShadowmaskMode CurrentValue =>
			QualitySettings.shadowmaskMode;

		protected override void OnApply(ShadowmaskMode value) =>
			QualitySettings.shadowmaskMode = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowmaskModeSetting
	{
		private const string FILE_NAME = nameof(ShadowmaskModeSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;
	}
}