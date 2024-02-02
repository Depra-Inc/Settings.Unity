// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Collections.Generic;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Base
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
		private const string MENU_NAME = MENU_PATH + SLASH + FILE_NAME;
	}
}