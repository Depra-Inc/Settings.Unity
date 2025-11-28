// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using Depra.Settings.Parameters;
using UnityEngine.UIElements;

namespace Depra.Settings.UIToolkit
{
	public sealed class FloatSettingsParameterElement : SettingsParameterElement<float>
	{
		private readonly Slider _slider;
		private readonly FloatField _valueField;

		public FloatSettingsParameterElement(SettingsParameter<float> parameter, VisualTreeAsset template) :
			base(parameter)
		{
			template.CloneTree(this);

			this.Q<Label>().text = parameter.DisplayName;

			_valueField = this.Q<FloatField>();
			_valueField.value = parameter.CurrentValue;

			_slider = this.Q<Slider>();
			_slider.value = parameter.CurrentValue;
			_slider.pageSize = 0.1f;

			if (parameter is IRangeSettingsParameter<float> rangeParameter)
			{
				_slider.lowValue = rangeParameter.MinValue;
				_slider.highValue = rangeParameter.MaxValue;
			}

			RegisterCallback<AttachToPanelEvent>(OnAttachedToPanel);
			RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);
		}

		public FloatSettingsParameterElement() { }

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

		private void OnValueFieldChanged(ChangeEvent<float> evt) => Parameter.Apply(evt.newValue);
		private void OnSliderValueChanged(ChangeEvent<float> evt) => Parameter.Apply(evt.newValue);

		private void UpdateSlider(float value)
		{
			_slider.SetValueWithoutNotify(value);
			_valueField.SetValueWithoutNotify(value);
		}

		public new class UxmlFactory : UxmlFactory<FloatSettingsParameterElement, UxmlTraits> { }

		public new class UxmlTraits : VisualElement.UxmlTraits { }
	}
}