// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class OptionSettingsParameterElement : VisualElement
	{
		private readonly DropdownField _dropdown;
		private readonly IOptionSettingParameter _parameter;

		public OptionSettingsParameterElement(IOptionSettingParameter option, VisualTreeAsset template)
		{
			_parameter = option;
			template.CloneTree(this);
			_dropdown = this.Q<DropdownField>();
			_dropdown.label = option.DisplayName;

			for (var index = 0; index < option.Count; index++)
			{
				_dropdown.choices.Add(option.GetDisplayName(index));
			}

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public OptionSettingsParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateDropdown(_parameter.CurrentIndex);
			_parameter.ValueChangedRaw += UpdateDropdown;
			_dropdown.RegisterValueChangedCallback(OnDropdownValueChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			_parameter.ValueChangedRaw -= UpdateDropdown;
			_dropdown.UnregisterValueChangedCallback(OnDropdownValueChanged);
		}

		private void OnDropdownValueChanged(ChangeEvent<string> evt)
		{
			var newIndex = _dropdown.choices.IndexOf(evt.newValue);
			if (newIndex >= 0)
			{
				_parameter.ApplyIndex(newIndex);
			}
		}

		private void UpdateDropdown(int index)
		{
			if (index >= 0 && index < _dropdown.choices.Count)
			{
				_dropdown.SetValueWithoutNotify(_dropdown.choices[index]);
			}
		}

		private void UpdateDropdown(object obj) => UpdateDropdown(_parameter.CurrentIndex);

		public new class UxmlFactory : UxmlFactory<DropdownSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}