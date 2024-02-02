// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using Depra.Settings.Runtime.Delegates;

namespace Depra.Settings.Parameters.Base
{
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