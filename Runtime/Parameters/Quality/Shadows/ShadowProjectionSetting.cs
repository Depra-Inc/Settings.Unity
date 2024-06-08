// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Shadows
{
	public sealed partial class ShadowProjectionSetting : SettingsParameter<ShadowProjection>
	{
		public override ShadowProjection CurrentValue => QualitySettings.shadowProjection;

		protected override void OnApply(ShadowProjection value) => QualitySettings.shadowProjection = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowProjectionSetting
	{
		private const string FILE_NAME = nameof(ShadowProjectionSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Shadows) + SLASH + FILE_NAME;
	}
}