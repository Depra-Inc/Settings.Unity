// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.External
{
	public sealed partial class ExternalIntegerSetting : SettingsParameter<int>
	{
		[SerializeField] private UnityEvent<int> _onValueChanged;

		public override int CurrentValue => default;

		protected override void OnApply(int value) =>
			_onValueChanged.Invoke(value);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ExternalIntegerSetting
	{
		private const string FILE_NAME = nameof(ExternalIntegerSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(External) + SEPARATOR + FILE_NAME;
	}
}