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

		public Int2SettingsParameterElement(SettingsParameter<Vector2Int> parameter) : base(parameter)
		{
			var label = this.Q<Label>();
			if (label == null)
			{
				label = new Label
				{
					text = parameter.DisplayName
				};

				label.AddToClassList("setting-item-label");
				Add(label);
			}

			_widthField = this.Q<IntegerField>("width-field");
			if (_widthField == null)
			{
				_widthField = new IntegerField("Width")
				{
					name = "width-field",
					value = parameter.CurrentValue.x
				};

				_widthField.AddToClassList("setting-item-field");
				Add(_widthField);
			}

			_heightField = this.Q<IntegerField>("height-field");
			if (_heightField == null)
			{
				_heightField = new IntegerField("Height")
				{
					name = "height-field",
					value = parameter.CurrentValue.y
				};

				_heightField.AddToClassList("setting-item-field");
				Add(_heightField);
			}

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