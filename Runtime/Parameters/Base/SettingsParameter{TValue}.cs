using System;
using System.Runtime.CompilerServices;
using Depra.Settings.Unity.Runtime.Delegates;
using Depra.Settings.Unity.Runtime.Save;
using UnityEngine;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
	public abstract class SettingsParameter<TValue> : SettingsParameter, ISettingParameter<TValue>
	{
		[SerializeField] private string _key;
		[SerializeField] private TValue _defaultValue;

		public event SettingValueChangedDelegate<TValue> ValueChanged;
		internal override event SettingValueChangedDelegate ValueChangedRaw;

		public abstract TValue CurrentValue { get; }
		public TValue DefaultValue => _defaultValue;

		internal override string Key => _key;
		internal override Type ValueType => typeof(TValue);
		internal override IPersistent Persistent => new DefaultSerializableState(this);

		private void Reset()
		{
			if (string.IsNullOrEmpty(_key))
			{
				_key = Name;
			}
		}

		public void Reload()
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
			value ??= _defaultValue;
			if (value.Equals(CurrentValue))
			{
				return;
			}

			OnApply(value);
			InvokeValueChanged(CurrentValue);
		}

		protected abstract void OnApply(TValue value);

		protected virtual void OnReload() => OnApply(_defaultValue);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void InvokeValueChanged(TValue value)
		{
			ValueChanged?.Invoke(value);
			ValueChangedRaw?.Invoke(CurrentValue);
		}

		private readonly struct DefaultSerializableState : IPersistent
		{
			private readonly SettingsParameter<TValue> _parameter;

			public DefaultSerializableState(SettingsParameter<TValue> parameter) =>
				_parameter = parameter;

			object IPersistent.CaptureState() => _parameter.CurrentValue;

			void IPersistent.RestoreState(object state)
			{
				var castedState = Parse(state);
				_parameter.Apply(castedState);
			}

			private TValue Parse(object state) => state switch
			{
				null => _parameter.DefaultValue,
				TValue castedState => castedState,
				_ => (TValue) Convert.ChangeType(state, typeof(TValue))
			};
		}
	}
}