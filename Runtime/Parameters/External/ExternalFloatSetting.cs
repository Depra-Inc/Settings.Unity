// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalFloatSetting : SettingsParameter<float>, IRangeSettingsParameter<float>
	{
		[SerializeField] private float _min;
		[SerializeField] private float _max = 1f;
		[SerializeField] private UnityEvent<float> _onValueChanged;

		private const string FILE_NAME = nameof(ExternalFloatSetting);
		private const string MENU_NAME = MENU_PATH + "External/" + FILE_NAME;

		private float _value;

		public override float CurrentValue => _value;
		float IRangeSettingsParameter<float>.MinValue => _min;
		float IRangeSettingsParameter<float>.MaxValue => _max;

		protected override void OnApply(float value)
		{
			_value = Mathf.Clamp(value, _min, _max);
			_onValueChanged?.Invoke(_value);
		}
	}
}