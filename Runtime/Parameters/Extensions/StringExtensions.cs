// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Text.RegularExpressions;

namespace Depra.Settings.Parameters.Extensions
{
	internal static class StringExtensions
	{
		public static string PutSpacesBeforeCapitals(this string self) => Regex
			.Replace(self, "([A-Z])", " $1", RegexOptions.Compiled)
			.Trim();
	}
}