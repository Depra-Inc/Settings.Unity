// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class FieldOfViewSetting : SettingsParameter<int>, IRangeSettingsParameter<int>
	{
		[SerializeField] private int _minValue = 60;
		[SerializeField] private int _maxValue = 140;

		public override int CurrentValue => (int)Camera.main!.fieldOfView;
		int IRangeSettingsParameter<int>.MinValue => _minValue;
		int IRangeSettingsParameter<int>.MaxValue => _maxValue;

		protected override void OnApply(int value) =>
			Camera.main!.fieldOfView = Mathf.Clamp(value, _minValue, _maxValue);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class FieldOfViewSetting
	{
		private const string FILE_NAME = nameof(FieldOfViewSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + SLASH + FILE_NAME;
	}
}