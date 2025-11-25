// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using Depra.Settings.Parameters.Extensions;
using UnityEngine;

namespace Depra.Settings.Parameters
{
	/// <summary>
	/// A class that all settings must inherit from.
	/// </summary>
	public abstract class SettingsParameter : ScriptableObject, ISettingsParameter
	{
		[field: SerializeField] public string Key { get; private set; }
		[field: SerializeField] public string DisplayName { get; private set; }

		public abstract event SettingValueChanged ValueChangedRaw;

		private void Reset()
		{
			Key = string.IsNullOrEmpty(Key)
				? DefaultName.RemoveBlackWords()
				: Key;

			DisplayName = string.IsNullOrEmpty(DisplayName)
				? DefaultName.RemoveBlackWords().PutSpacesBeforeCapitals()
				: DisplayName;
		}

		public abstract Type ValueType { get; }

		protected virtual string DefaultName => GetType().Name;

		public abstract void Reload();

		public abstract object CaptureState();

		public abstract void RestoreState(object state);

		[ContextMenu(nameof(ResetKey))]
		private string ResetKey() => Key = DefaultName.RemoveBlackWords();

		[ContextMenu(nameof(ResetName))]
		private string ResetName() => DisplayName = DefaultName
			.RemoveBlackWords()
			.PutSpacesBeforeCapitals();
	}
}