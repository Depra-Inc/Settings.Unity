// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.External
{
	public sealed partial class ExternalBoolSetting : SettingsParameter<bool>
	{
		[SerializeField] private UnityEvent<bool> _onValueChanged;

		public override bool CurrentValue => default;

		protected override void OnApply(bool value) => _onValueChanged.Invoke(value);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ExternalBoolSetting
	{
		private const string FILE_NAME = nameof(ExternalBoolSetting);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(External) + SLASH + FILE_NAME;
	}
}