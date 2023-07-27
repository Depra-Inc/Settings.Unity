// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class SettingsPreset : ScriptableObject
	{
		private const string FILE_NAME = nameof(SettingsPreset);
		private const string MENU_NAME = MODULE_PATH + "/" + FILE_NAME;

		[SerializeField] private SettingsParameter[] _parameters;
		
		public IEnumerable<SettingsParameter> Parameters => _parameters;
	}
}