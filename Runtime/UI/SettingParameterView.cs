// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine;

namespace Depra.Settings.UI
{
	public abstract class SettingParameterView<TValue> : MonoBehaviour
	{
		[field: SerializeField] protected SettingsParameter<TValue> Parameter { get; private set; }
	}
}