// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using Depra.Settings.Runtime.Delegates;
using UnityEngine;

namespace Depra.Settings.Parameters.Base
{
	/// <summary>
	/// A class that all settings must inherit from.
	/// </summary>
	public abstract partial class SettingsParameter : ScriptableObject, ISettingsParameter
	{
		[field: SerializeField] public string Key { get; private set; }
		[field: SerializeField] public string DisplayName { get; private set; }

		public abstract event SettingValueChanged ValueChangedRaw;

		private void Reset()
		{
			Key = string.IsNullOrEmpty(Key) ? ResetKey() : Key;
			DisplayName = string.IsNullOrEmpty(DisplayName) ? ResetName() : DisplayName;
		}

		public abstract Type ValueType { get; }
		
		protected virtual string DefaultName => GetType().Name;

		public abstract void Reload();

		public abstract object CaptureState();

		public abstract void RestoreState(object state);
	}
}