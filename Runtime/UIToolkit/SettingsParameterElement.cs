// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public abstract class SettingsParameterElement<TValue> : VisualElement
	{
		[UsedImplicitly]
		protected SettingsParameterElement() { }

		protected SettingsParameterElement(SettingsParameter<TValue> parameter) => Parameter = parameter;

		protected SettingsParameter<TValue> Parameter { get; private set; }
	}
}