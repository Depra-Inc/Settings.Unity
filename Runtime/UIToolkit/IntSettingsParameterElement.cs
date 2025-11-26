// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class IntSettingsParameterElement : SettingsParameterElement<int>
	{
		private readonly SliderInt _slider;
		private readonly IntegerField _valueField;

		public IntSettingsParameterElement(SettingsParameter<int> parameter) : base(parameter)
		{
			var label = this.Q<Label>("label");
			if (label == null)
			{
				label = new Label
				{
					text = parameter.DisplayName
				};

				label.AddToClassList("setting-item-label");
				Add(label);
			}

			_valueField = this.Q<IntegerField>("value-field");
			if (_valueField == null)
			{
				_valueField = new IntegerField
				{
					value = parameter.CurrentValue
				};

				_valueField.AddToClassList("setting-item-field");
				Add(_valueField);
			}

			_slider = this.Q<SliderInt>();
			if (_slider == null)
			{
				_slider = new SliderInt
				{
					value = parameter.CurrentValue
				};

				if (parameter is IRangeSettingsParameter<int> rangeParameter)
				{
					_slider.lowValue = rangeParameter.MinValue;
					_slider.highValue = rangeParameter.MaxValue;
				}

				_slider.AddToClassList("setting-item-slider");
				Add(_slider);
			}

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public IntSettingsParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateSlider(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateSlider;
			_slider.RegisterValueChangedCallback(OnSliderValueChanged);
			_valueField.RegisterValueChangedCallback(OnValueFieldChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			Parameter.ValueChanged -= UpdateSlider;
			_slider.UnregisterValueChangedCallback(OnSliderValueChanged);
			_valueField.UnregisterValueChangedCallback(OnValueFieldChanged);
		}

		private void OnValueFieldChanged(ChangeEvent<int> evt) => Parameter.Apply(evt.newValue);
		private void OnSliderValueChanged(ChangeEvent<int> evt) => Parameter.Apply(evt.newValue);

		private void UpdateSlider(int value)
		{
			_slider.SetValueWithoutNotify(value);
			_valueField.SetValueWithoutNotify(value);
		}
	}
}