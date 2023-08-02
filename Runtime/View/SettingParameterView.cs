// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;

namespace Depra.Settings.Runtime.View
{
	public abstract class SettingParameterView<TValue> : MonoBehaviour
	{
		[field: SerializeField] protected SettingsParameter<TValue> Parameter { get; private set; }
	}
}