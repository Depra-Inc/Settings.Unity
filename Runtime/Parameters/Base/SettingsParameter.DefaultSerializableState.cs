// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Settings.Unity.Runtime.Persistent;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
	public abstract partial class SettingsParameter<TValue>
	{
		private readonly struct DefaultSerializableState : IPersistent
		{
			private readonly SettingsParameter<TValue> _parameter;

			public DefaultSerializableState(SettingsParameter<TValue> parameter) =>
				_parameter = parameter;

			object IPersistent.CaptureState() => _parameter.CurrentValue;

			void IPersistent.RestoreState(object state)
			{
				var castedState = Parse(state);
				_parameter.ApplyWithoutNotify(castedState);
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