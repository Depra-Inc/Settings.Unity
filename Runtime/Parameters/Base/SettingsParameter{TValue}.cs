// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Depra.Settings.Parameters
{
	public abstract class SettingsParameter<TValue> : SettingsParameter
	{
		[SerializeField] private TValue _defaultValue;

		public event SettingValueChanged<TValue> ValueChanged;
		public override event SettingValueChanged ValueChangedRaw;

		public abstract TValue CurrentValue { get; }
		public virtual TValue DefaultValue => _defaultValue;
		public override Type ValueType => typeof(TValue);

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
			InvokeValueChanged(value);
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
			ValueChangedRaw?.Invoke(value);
		}
	}
}