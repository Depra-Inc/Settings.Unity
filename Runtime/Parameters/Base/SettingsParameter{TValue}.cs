// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;
using Depra.Settings.Unity.Runtime.Delegates;
using Depra.Settings.Unity.Runtime.Persistent;
using UnityEngine;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
	public abstract partial class SettingsParameter<TValue> : SettingsParameter
	{
		[SerializeField] private TValue _defaultValue;

		public event SettingValueChangedDelegate<TValue> ValueChanged;
		internal override event SettingValueChangedDelegate ValueChangedRaw;

		public abstract TValue CurrentValue { get; }
		public TValue DefaultValue => _defaultValue;
		
		internal override Type ValueType => typeof(TValue);
		internal override IPersistent Persistent => new DefaultSerializableState(this);

		public override void Reload()
		{
			if (CurrentValue.Equals(_defaultValue))
			{
				return;
			}

			OnReload();
			InvokeValueChanged(CurrentValue);
		}

		public void Apply(TValue value)
		{
			ApplyWithoutNotify(value);
			InvokeValueChanged(CurrentValue);
		}

		protected abstract void OnApply(TValue value);

		protected virtual void OnReload() => OnApply(_defaultValue);

		private void ApplyWithoutNotify(TValue value)
		{
			value ??= _defaultValue;
			if (value.Equals(CurrentValue))
			{
				return;
			}

			OnApply(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InvokeValueChanged(TValue value)
		{
			ValueChanged?.Invoke(value);
			ValueChangedRaw?.Invoke(CurrentValue);
		}
	}
}