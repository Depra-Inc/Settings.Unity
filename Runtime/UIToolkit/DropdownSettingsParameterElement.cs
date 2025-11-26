// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class DropdownSettingsParameterElement : SettingsParameterElement<int>
	{
		private readonly DropdownField _dropdown;

		public DropdownSettingsParameterElement(ArraySettingParameter<string> parameter) : base(parameter)
		{
			_dropdown = this.Q<DropdownField>();
			if (_dropdown == null)
			{
				_dropdown = new DropdownField
				{
					label = parameter.DisplayName
				};

				_dropdown.choices.AddRange(parameter.AllValues);
				_dropdown.labelElement.AddToClassList("setting-item-label");
				Add(_dropdown);
			}

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public DropdownSettingsParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateDropdown(Parameter.CurrentValue);
			Parameter.ValueChanged += UpdateDropdown;
			_dropdown.RegisterValueChangedCallback(OnDropdownValueChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			Parameter.ValueChanged -= UpdateDropdown;
			_dropdown.UnregisterValueChangedCallback(OnDropdownValueChanged);
		}

		private void OnDropdownValueChanged(ChangeEvent<string> evt)
		{
			var newIndex = _dropdown.choices.IndexOf(evt.newValue);
			if (newIndex >= 0)
			{
				Parameter.Apply(newIndex);
			}
		}

		private void UpdateDropdown(int value)
		{
			if (value >= 0 && value < _dropdown.choices.Count)
			{
				_dropdown.SetValueWithoutNotify(_dropdown.choices[value]);
			}
		}

		public new class UxmlFactory : UxmlFactory<DropdownSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}