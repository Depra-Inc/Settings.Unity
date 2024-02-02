// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Misc
{
	public sealed partial class BillboardsFaceCameraPositionSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.billboardsFaceCameraPosition;

		protected override void OnApply(bool value) => QualitySettings.billboardsFaceCameraPosition = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class BillboardsFaceCameraPositionSetting
	{
		private const string FILE_NAME = nameof(BillboardsFaceCameraPositionSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Misc) + SLASH + FILE_NAME;
	}
}