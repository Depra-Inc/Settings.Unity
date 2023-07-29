// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.External
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalIntegerSetting : SettingsParameter<int>
	{
		private const string FILE_NAME = nameof(ExternalIntegerSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(External) + SEPARATOR + FILE_NAME;

		[SerializeField] private UnityEvent<int> _onValueChanged;

		public override int CurrentValue => default;

		protected override void OnApply(int value) =>
			_onValueChanged.Invoke(value);
	}
}