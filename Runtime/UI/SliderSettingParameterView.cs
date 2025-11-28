// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Module;

namespace Depra.Settings.UI
{
	public sealed partial class SliderSettingParameterView : SettingParameterView<float>
	{
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

		private void UpdateSlider(float value)
		{
			if (Mathf.Approximately(value, _slider.value) == false)
			{
				_slider.SetValueWithoutNotify(value);
			}
		}
	}

	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed partial class SliderSettingParameterView
	{
		private const string FILE_NAME = nameof(SliderSettingParameterView);
		private const string MENU_NAME = MENU_PATH + nameof(UI) + SLASH + FILE_NAME;
	}
}