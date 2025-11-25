// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class SliderSettingParameterElement : SettingParameterElement<float>
	{
		private readonly Slider _slider;
		private readonly Label _valueLabel;

		public SliderSettingParameterElement(SettingsParameter<float> parameter) : base(parameter)
		{
			_slider = this.Q<Slider>();
			if (_slider == null)
			{
				_slider = new Slider
				{
					// lowValue = MIN_VALUE,
					// highValue = MAX_VALUE
				};
				Add(_slider);
			}
			else
			{
				// _slider.lowValue = MIN_VALUE;
				// _slider.highValue = MAX_VALUE;
			}

			_slider.label = parameter.DisplayName;
			_valueLabel = this.Q<Label>("value-label");
			if (_valueLabel == null)
			{
				_valueLabel = new Label { name = "value-label" };
				_slider.Add(_valueLabel);
			}

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public SliderSettingParameterElement() { }

		private void OnAttachedToPanel(AttachToPanelEvent evt)
		{
			UpdateSlider(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateSlider;
			_slider.RegisterValueChangedCallback(OnSliderValueChanged);
		}

		private void OnDetachedFromPanel(DetachFromPanelEvent evt)
		{
			Parameter.ValueChanged -= UpdateSlider;
			_slider.UnregisterValueChangedCallback(OnSliderValueChanged);
		}

		private void OnSliderValueChanged(ChangeEvent<float> evt)
		{
			ApplyParameter(evt.newValue);
		}

		private void ApplyParameter(float value)
		{
			var convertedValue = Mathf.Log10(value) * 20;
			Parameter.Apply(convertedValue);
		}

		private void UpdateSlider(float value)
		{
			var convertedValue = Mathf.Pow(10, value / 20);
			_slider.SetValueWithoutNotify(convertedValue);
			_valueLabel.text = value.ToString("F1");
		}

		public new class UxmlFactory : UxmlFactory<SliderSettingParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}