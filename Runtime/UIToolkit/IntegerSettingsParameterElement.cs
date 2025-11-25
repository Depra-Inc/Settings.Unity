// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class IntegerSettingsParameterElement : SettingParameterElement<int>
	{
		private readonly IntegerField _field;

		public IntegerSettingsParameterElement(SettingsParameter<int> parameter) : base(parameter)
		{
			_field = this.Q<IntegerField>();
			if (_field == null)
			{
				_field = new IntegerField();
				Add(_field);
				UpdateField(parameter.CurrentValue);
			}

			_field.label = parameter.DisplayName;
			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public IntegerSettingsParameterElement() { }

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

		private void OnFieldValueChanged(ChangeEvent<int> evt)
		{
			Parameter.Apply(evt.newValue);
		}

		private void UpdateField(int value)
		{
			_field.SetValueWithoutNotify(value);
		}

		public new class UxmlFactory : UxmlFactory<IntegerSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}