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

		public IntSettingsParameterElement(SettingsParameter<int> parameter, VisualTreeAsset template) : base(parameter)
		{
			template.CloneTree(this);

			this.Q<Label>().text = parameter.DisplayName;

			_valueField = this.Q<IntegerField>();
			_valueField.value = parameter.CurrentValue;

			_slider = this.Q<SliderInt>();
			_slider.value = parameter.CurrentValue;
			if (parameter is IRangeSettingsParameter<int> rangeParameter)
			{
				_slider.lowValue = rangeParameter.MinValue;
				_slider.highValue = rangeParameter.MaxValue;
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