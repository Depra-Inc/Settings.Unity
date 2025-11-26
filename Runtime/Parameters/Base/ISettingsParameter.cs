// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Settings.Parameters
{
	public interface IRangeSettingsParameter<out TValue>
	{
		TValue MinValue { get; }
		TValue MaxValue { get; }
	}
	
	public interface ISettingsParameter
	{
		event SettingValueChanged ValueChangedRaw;

		Type ValueType { get; }
		
		string Key { get; }

		string DisplayName { get; }

		void Reload();

		object CaptureState();

		void RestoreState(object state);
	}
}