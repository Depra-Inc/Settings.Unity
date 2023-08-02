// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;
using Depra.Settings.Runtime.Delegates;
using UnityEngine;

namespace Depra.Settings.Runtime.Parameters.Base
{
	public abstract class SettingsParameter<TValue> : SettingsParameter
	{
		[SerializeField] private TValue _defaultValue;

		public event SettingValueChangedDelegate<TValue> ValueChanged;
		public override event SettingValueChangedDelegate ValueChangedRaw;

		public abstract TValue CurrentValue { get; }
		public override Type ValueType => typeof(TValue);
		
		public TValue DefaultValue => _defaultValue;
		
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

		public override object CaptureState() => CurrentValue;

		public override void RestoreState(object state) => 
			ApplyWithoutNotify(Parse(state));

		private TValue Parse(object state) => state switch
		{
			null => DefaultValue,
			TValue castedState => castedState,
			_ => (TValue) Convert.ChangeType(state, typeof(TValue))
		};

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