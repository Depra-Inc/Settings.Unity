// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalIntegerSetting : SettingsParameter<int>, IRangeSettingsParameter<int>
	{
		[SerializeField] private int _minValue;
		[SerializeField] private int _maxValue = 100;
		[SerializeField] private UnityEvent<int> _onValueChanged;

		private const string FILE_NAME = nameof(ExternalIntegerSetting);
		private const string MENU_NAME = MENU_PATH + "External/" + FILE_NAME;

		private int _value;

		public override int CurrentValue => _value;
		int IRangeSettingsParameter<int>.MinValue => _minValue;
		int IRangeSettingsParameter<int>.MaxValue => _maxValue;

		protected override void OnApply(int value)
		{
			_value = Mathf.Clamp(value, _minValue, _maxValue);
			_onValueChanged?.Invoke(_value);
		}
	}
}