// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.External
{
	public sealed partial class ExternalIntegerSetting : SettingsParameter<int>
	{
		[SerializeField] private UnityEvent<int> _onValueChanged;

		public override int CurrentValue => default;

		protected override void OnApply(int value) => _onValueChanged.Invoke(value);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ExternalIntegerSetting
	{
		private const string FILE_NAME = nameof(ExternalIntegerSetting);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(External) + SLASH + FILE_NAME;
	}
}