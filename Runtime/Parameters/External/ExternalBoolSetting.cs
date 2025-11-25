// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.External
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalBoolSetting : ExternalSetting<bool>
	{
		private const string FILE_NAME = nameof(ExternalBoolSetting);
		private const string MENU_NAME = MENU_PATH + nameof(External) + SLASH + FILE_NAME;
	}
}