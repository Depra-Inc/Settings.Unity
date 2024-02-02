// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class FieldOfViewSetting : SettingsParameter<float>
	{
		public override float CurrentValue => Camera.main!.fieldOfView;

		protected override void OnApply(float value) => Camera.main!.fieldOfView = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class FieldOfViewSetting
	{
		private const string FILE_NAME = nameof(FieldOfViewSetting);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(Screen) + SLASH + FILE_NAME;
	}
}