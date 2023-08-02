// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Text.RegularExpressions;

namespace Depra.Settings.Runtime.Parameters.Extensions
{
	internal static class StringExtensions
	{
		public static string PutSpacesBeforeCapitals(this string self) => Regex
			.Replace(self, "([A-Z])", " $1", RegexOptions.Compiled)
			.Trim();
	}
}