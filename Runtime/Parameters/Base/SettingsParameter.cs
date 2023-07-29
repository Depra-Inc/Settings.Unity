// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;
using Depra.Settings.Unity.Runtime.Delegates;
using Depra.Settings.Unity.Runtime.Parameters.Extensions;
using Depra.Settings.Unity.Runtime.Persistent;
using UnityEngine;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
	/// <summary>
	/// A class that all settings must inherit from.
	/// </summary>
	public abstract class SettingsParameter : ScriptableObject
	{
		[field: SerializeField] internal string Key { get; private set; }
		[field: SerializeField] public string DisplayName { get; private set; }

		internal abstract event SettingValueChangedDelegate ValueChangedRaw;

		private void Reset()
		{
			Key = string.IsNullOrEmpty(Key) ? ResetKey() : Key;
			DisplayName = string.IsNullOrEmpty(DisplayName) ? ResetName() : DisplayName;
		}

		internal abstract Type ValueType { get; }
		internal abstract IPersistent Persistent { get; }
		protected virtual string DefaultName => GetType().Name;

		public abstract void Reload();

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