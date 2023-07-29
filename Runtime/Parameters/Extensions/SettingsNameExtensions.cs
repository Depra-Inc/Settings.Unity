// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Linq;

namespace Depra.Settings.Unity.Runtime.Parameters.Extensions
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