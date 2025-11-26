// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalBoolSetting : SettingsParameter<bool>
	{
		[SerializeField] private UnityEvent<bool> _onValueChanged;

		private const string FILE_NAME = nameof(ExternalBoolSetting);
		private const string MENU_NAME = MENU_PATH + "External/" + FILE_NAME;

		private bool _currentValue;
		public override bool CurrentValue => _currentValue;

		protected override void OnApply(bool value)
		{
			_currentValue = value;
			_onValueChanged?.Invoke(value);
		}
	}
}