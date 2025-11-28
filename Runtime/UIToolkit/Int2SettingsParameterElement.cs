// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class Int2SettingsParameterElement : SettingsParameterElement<Vector2Int>
	{
		private readonly IntegerField _widthField;
		private readonly IntegerField _heightField;

		public Int2SettingsParameterElement(SettingsParameter<Vector2Int> parameter, VisualTreeAsset template) :
			base(parameter)
		{
			template.CloneTree(this);

			this.Q<Label>().text = parameter.DisplayName;

			_widthField = this.Q<IntegerField>("x-field");
			_widthField.value = parameter.CurrentValue.x;

			_heightField = this.Q<IntegerField>("y-field");
			_heightField.value = parameter.CurrentValue.y;

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public Int2SettingsParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateFields(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateFields;
			_widthField.RegisterValueChangedCallback(OnWidthFieldChanged);
			_heightField.RegisterValueChangedCallback(OnHeightFieldChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			Parameter.ValueChanged -= UpdateFields;
			_widthField.UnregisterValueChangedCallback(OnWidthFieldChanged);
			_heightField.UnregisterValueChangedCallback(OnHeightFieldChanged);
		}

		private void OnWidthFieldChanged(ChangeEvent<int> evt) =>
			Parameter.Apply(new Vector2Int(evt.newValue, Parameter.CurrentValue.y));

		private void OnHeightFieldChanged(ChangeEvent<int> evt) =>
			Parameter.Apply(new Vector2Int(Parameter.CurrentValue.x, evt.newValue));

		private void UpdateFields(Vector2Int value)
		{
			_widthField.SetValueWithoutNotify(value.x);
			_heightField.SetValueWithoutNotify(value.y);
		}

		public new class UxmlFactory : UxmlFactory<Int2SettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}