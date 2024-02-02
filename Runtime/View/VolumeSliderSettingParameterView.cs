// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Module;

namespace Depra.Settings.Runtime.View
{
	public sealed partial class VolumeSliderSettingParameterView : SettingParameterView<float>
	{
		private const float MAX_VALUE = 1f;
		private const float MIN_VALUE = 0.001f;

		[SerializeField] private Slider _slider;

		private void Awake()
		{
			_slider.minValue = MIN_VALUE;
			_slider.maxValue = MAX_VALUE;
		}

		private void OnEnable()
		{
			UpdateSlider(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateSlider;
			_slider.onValueChanged.AddListener(ApplyParameter);
		}

		private void OnDisable() => _slider.onValueChanged.RemoveListener(ApplyParameter);

		private void ApplyParameter(float value)
		{
			var convertedValue = Mathf.Log10(value) * 20;
			Parameter.Apply(convertedValue);
		}

		private void UpdateSlider(float value)
		{
			var convertedValue = Mathf.Pow(10, value / 20);
			_slider.SetValueWithoutNotify(convertedValue);
		}
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class VolumeSliderSettingParameterView
	{
		private const string FILE_NAME = nameof(VolumeSliderSettingParameterView);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(View) + SLASH + FILE_NAME;
	}
}