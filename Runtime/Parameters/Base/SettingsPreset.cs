// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Base
{
	public sealed partial class SettingsPreset : ScriptableObject
	{
		[SerializeField] private SettingsParameter[] _parameters;

		public IEnumerable<SettingsParameter> Parameters => _parameters;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class SettingsPreset
	{
		private const string FILE_NAME = nameof(SettingsPreset);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + FILE_NAME;
	}
}