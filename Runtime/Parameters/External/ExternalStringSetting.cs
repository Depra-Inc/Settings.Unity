// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalStringSetting : SettingsParameter<string>
	{
		[SerializeField] private UnityEvent<string> _onValueChanged;

		private const string FILE_NAME = nameof(ExternalStringSetting);
		private const string MENU_NAME = MENU_PATH + "External/" + FILE_NAME;

		private string _value;
		public override string CurrentValue => _value;

		protected override void OnApply(string value)
		{
			_value = value;
			_onValueChanged?.Invoke(value);
		}
	}
}