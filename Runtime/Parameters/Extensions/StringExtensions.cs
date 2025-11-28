// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Linq;
using System.Text.RegularExpressions;

namespace Depra.Settings.Parameters.Extensions
{
	internal static class StringExtensions
	{
		private static readonly string[] BLACK_WORDS =
		{
			"Setting",
			"Settings",
			"Parameter",
			"Parameters"
		};

		public static string RemoveBlackWords(this string self) =>
			BLACK_WORDS.Aggregate(self, (current, word) =>
				current.Replace(word, string.Empty));

		public static string PutSpacesBeforeCapitals(this string self) => Regex
			.Replace(self, "([A-Z])", " $1", RegexOptions.Compiled)
			.Trim();
	}
}