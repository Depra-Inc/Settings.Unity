// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.View
{
	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed class SliderSettingParameterView : SettingParameterView<float>
	{
		private const string FILE_NAME = nameof(SliderSettingParameterView);
		private const string MENU_NAME = MODULE_PATH + "/" + nameof(View) + "/" + FILE_NAME;

		[SerializeField] private Slider _slider;
		
		private void OnEnable()
		{
			UpdateSlider(Parameter.CurrentValue);
			
			Parameter.ValueChanged += UpdateSlider;
			_slider.onValueChanged.AddListener(OnSettingValueChanged);
		}

		private void OnDisable()
		{
			Parameter.ValueChanged -= UpdateSlider;
			_slider.onValueChanged.RemoveListener(OnSettingValueChanged);
		}

		private void UpdateSlider(float value) => _slider.SetValueWithoutNotify(value);

		private void OnSettingValueChanged(float value) => Parameter.Apply(value);
	}
}