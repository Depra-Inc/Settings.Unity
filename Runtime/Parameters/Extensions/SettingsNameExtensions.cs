// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Linq;

namespace Depra.Settings.Parameters.Extensions
{
	internal static class SettingsNameExtensions
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
	}
}