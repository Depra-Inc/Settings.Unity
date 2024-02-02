// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowmaskModeSetting : SettingsParameter<ShadowmaskMode>
	{
		public override ShadowmaskMode CurrentValue => QualitySettings.shadowmaskMode;

		protected override void OnApply(ShadowmaskMode value) => QualitySettings.shadowmaskMode = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowmaskModeSetting
	{
		private const string FILE_NAME = nameof(ShadowmaskModeSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}