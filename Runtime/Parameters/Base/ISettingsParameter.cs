// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Settings.Runtime.Delegates;

namespace Depra.Settings.Runtime.Parameters.Base
{
	public interface ISettingsParameter
	{
		event SettingValueChangedDelegate ValueChangedRaw;

		Type ValueType { get; }
		
		string Key { get; }

		string DisplayName { get; }

		void Reload();

		object CaptureState();

		void RestoreState(object state);
	}
}