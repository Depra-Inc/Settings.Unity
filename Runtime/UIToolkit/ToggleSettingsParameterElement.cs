// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class ToggleSettingsParameterElement : SettingsParameterElement<bool>
	{
		private readonly Toggle _toggle;

		public ToggleSettingsParameterElement(SettingsParameter<bool> parameter, VisualTreeAsset template) :
			base(parameter)
		{
			template.CloneTree(this);

			_toggle = this.Q<Toggle>();
			_toggle.label = parameter.DisplayName;

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public ToggleSettingsParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateToggle(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateToggle;
			_toggle.RegisterValueChangedCallback(OnToggleValueChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			Parameter.ValueChanged -= UpdateToggle;
			_toggle.UnregisterValueChangedCallback(OnToggleValueChanged);
		}

		private void OnToggleValueChanged(ChangeEvent<bool> evt) => Parameter.Apply(evt.newValue);

		private void UpdateToggle(bool value) => _toggle.SetValueWithoutNotify(value);

		public new class UxmlFactory : UxmlFactory<ToggleSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}