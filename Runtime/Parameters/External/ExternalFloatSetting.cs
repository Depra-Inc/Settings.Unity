// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.External
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalFloatSetting : SettingsParameter<float>
	{
		private const string FILE_NAME = nameof(ExternalFloatSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(External) + SEPARATOR + FILE_NAME;

		[SerializeField] private UnityEvent<float> _onValueChanged;

		public override float CurrentValue => default;

		protected override void OnApply(float value) =>
			_onValueChanged.Invoke(value);
	}
}