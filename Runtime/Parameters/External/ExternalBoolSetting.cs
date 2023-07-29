// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.External
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalBoolSetting : SettingsParameter<bool>
	{
		private const string FILE_NAME = nameof(ExternalBoolSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(External) + SEPARATOR + FILE_NAME;

		[SerializeField] private UnityEvent<bool> _onValueChanged;

		public override bool CurrentValue => default;

		protected override void OnApply(bool value) =>
			_onValueChanged.Invoke(value);
	}
}