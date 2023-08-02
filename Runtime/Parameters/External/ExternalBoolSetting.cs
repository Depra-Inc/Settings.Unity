// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.External
{
	public sealed partial class ExternalBoolSetting : SettingsParameter<bool>
	{
		[SerializeField] private UnityEvent<bool> _onValueChanged;

		public override bool CurrentValue => default;

		protected override void OnApply(bool value) =>
			_onValueChanged.Invoke(value);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ExternalBoolSetting
	{
		private const string FILE_NAME = nameof(ExternalBoolSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(External) + SEPARATOR + FILE_NAME;
	}
}