// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Depra.Settings.UI")]
[assembly: InternalsVisibleTo("Depra.Settings.URP")]

namespace Depra.Settings
{
	internal static class Module
	{
		internal const string SLASH = "/";
		internal const int DEFAULT_ORDER = 51;
		internal const string MENU_PATH = nameof(Depra) + "/" + nameof(Settings) + "/";
	}
}