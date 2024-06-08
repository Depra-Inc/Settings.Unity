// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.External
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ExternalFloatSetting : ExternalSetting<float>
	{
		private const string FILE_NAME = nameof(ExternalFloatSetting);
		private const string MENU_NAME = MENU_PATH + nameof(External) + SLASH + FILE_NAME;
	}
}