// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class FloatSettingsParameterElement : SettingParameterElement<float>
	{
		private readonly FloatField _field;

		public FloatSettingsParameterElement(SettingsParameter<float> parameter) : base(parameter)
		{
			_field = this.Q<FloatField>();
			if (_field == null)
			{
				_field = new FloatField();
				Add(_field);
				UpdateField(parameter.CurrentValue);
			}

			_field.label = parameter.DisplayName;
			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public FloatSettingsParameterElement() { }

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

		private void OnFieldValueChanged(ChangeEvent<float> evt)
		{
			Parameter.Apply(evt.newValue);
		}

		private void UpdateField(float value)
		{
			_field.SetValueWithoutNotify(value);
		}

		public new class UxmlFactory : UxmlFactory<FloatSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}