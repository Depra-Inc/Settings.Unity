// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class EnumSettingsParameterElement : SettingParameterElement<Enum>
	{
		private readonly EnumField _field;

		public EnumSettingsParameterElement(SettingsParameter<Enum> parameter) : base(parameter)
		{
			_field = this.Q<EnumField>();
			if (_field == null)
			{
				_field = new EnumField();
				_field.Init(parameter.CurrentValue);
				Add(_field);
			}

			_field.label = parameter.DisplayName;
			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public EnumSettingsParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateField(Parameter.CurrentValue);
			Parameter.ValueChanged += UpdateField;
			_field.RegisterValueChangedCallback(OnFieldValueChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			Parameter.ValueChanged -= UpdateField;
			_field.UnregisterValueChangedCallback(OnFieldValueChanged);
		}

		private void OnFieldValueChanged(ChangeEvent<Enum> evt)
		{
			Parameter.Apply(evt.newValue);
		}

		private void UpdateField(Enum value)
		{
			_field.SetValueWithoutNotify(value);
		}

		public new class UxmlFactory : UxmlFactory<EnumSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}