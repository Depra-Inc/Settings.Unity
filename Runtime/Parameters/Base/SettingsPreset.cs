// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class SettingsPreset : ScriptableObject
	{
		private const string FILE_NAME = nameof(SettingsPreset);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + FILE_NAME;

		[SerializeField] private SettingsParameter[] _parameters;

		public IEnumerable<SettingsParameter> Parameters => _parameters;
	}
}