// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.Runtime.CompilerServices;
using Depra.Settings.Parameters.Extensions;
using UnityEngine;

namespace Depra.Settings.Parameters.Base
{
	public abstract partial class SettingsParameter
	{
		[ContextMenu(nameof(ResetKey))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string ResetKey() => Key = DefaultName.RemoveBlackWords();

		[ContextMenu(nameof(ResetName))]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string ResetName() => DisplayName = DefaultName
			.RemoveBlackWords()
			.PutSpacesBeforeCapitals();
	}
}