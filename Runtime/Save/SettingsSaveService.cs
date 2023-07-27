using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Depra.Settings.Unity.Runtime.Parameters.Base;

namespace Depra.Settings.Unity.Runtime.Save
{
	public sealed class SettingsSaveService : IDisposable
	{
		private readonly ISaveService _saveService;
		private readonly IEnumerable<ParameterContainer> _parameters;

		public SettingsSaveService(ISaveService saveService, IEnumerable<SettingsParameter> parameters)
		{
			_saveService = saveService ?? throw new ArgumentNullException(nameof(saveService));
			_parameters = parameters.Select(parameter => new ParameterContainer(parameter));
			
			SubscribeAll();
		}

		public void Dispose() => UnsubscribeAll();

		public void SaveAll()
		{
			foreach (var container in _parameters)
			{
				Save(container.Parameter);
			}
		}

		public void LoadAll()
		{
			foreach (var container in _parameters)
			{
				Load(container.Parameter);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Save(SettingsParameter parameter)
		{
			var capturedState = parameter.Persistent.CaptureState();
			_saveService.Save(parameter.Key, capturedState, parameter.ValueType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Load(SettingsParameter parameter)
		{
			if (_saveService.HasKey(parameter.Key) == false)
			{
				return;
			}
			
			var loadedState = _saveService.Load(parameter.Key, parameter.ValueType);
			parameter.Persistent.RestoreState(loadedState);
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SubscribeAll()
		{
			foreach (var container in _parameters)
			{
				container.ValueChanged += OnSettingValueChanged;
			}
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UnsubscribeAll()
		{
			foreach (var container in _parameters)
			{
				container.ValueChanged -= OnSettingValueChanged;
			}
		}

		private void OnSettingValueChanged(SettingsParameter parameter, object value) =>
			_saveService.Save(parameter.Key, value, parameter.ValueType);

		private sealed class ParameterContainer : IDisposable
		{
			public event Action<SettingsParameter, object> ValueChanged;

			public ParameterContainer(SettingsParameter parameter)
			{
				Parameter = parameter;
				Parameter.ValueChangedRaw += OnSettingValueChanged;
			}

			public void Dispose() =>
				Parameter.ValueChangedRaw -= OnSettingValueChanged;

			public SettingsParameter Parameter { get; }

			private void OnSettingValueChanged(object value) =>
				ValueChanged?.Invoke(Parameter, value);
		}
	}
}