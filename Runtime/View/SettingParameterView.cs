// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;

namespace Depra.Settings.View
{
	public abstract class SettingParameterView<TValue> : MonoBehaviour
	{
		[field: SerializeField] protected SettingsParameter<TValue> Parameter { get; private set; }
	}
}