// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Settings.Runtime.Delegates;
using UnityEngine;

namespace Depra.Settings.Runtime.Parameters.Base
{
	/// <summary>
	/// A class that all settings must inherit from.
	/// </summary>
	public abstract partial class SettingsParameter : ScriptableObject, ISettingsParameter
	{
		[field: SerializeField] public string Key { get; private set; }
		[field: SerializeField] public string DisplayName { get; private set; }

		public abstract event SettingValueChangedDelegate ValueChangedRaw;

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