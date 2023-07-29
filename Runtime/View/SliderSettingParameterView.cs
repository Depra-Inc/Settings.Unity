// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.View
{
	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed class SliderSettingParameterView : SettingParameterView<float>
	{
		private const string FILE_NAME = nameof(SliderSettingParameterView);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(View) + SEPARATOR + FILE_NAME;

		[SerializeField] private Slider _slider;

		private void OnEnable()
		{
			UpdateSlider(Parameter.CurrentValue);

			Parameter.ValueChanged += UpdateSlider;
			_slider.onValueChanged.AddListener(ApplyParameter);
		}

		private void OnDisable()
		{
			Parameter.ValueChanged -= UpdateSlider;
			_slider.onValueChanged.RemoveListener(ApplyParameter);
		}

		private void ApplyParameter(float value) => Parameter.Apply(value);

		private void UpdateSlider(float value) => _slider.SetValueWithoutNotify(value);
	}
}