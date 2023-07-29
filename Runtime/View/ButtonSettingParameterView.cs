using UnityEngine;
using UnityEngine.UI;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.View
{
	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed class ButtonSettingParameterView : SettingParameterView<bool>
	{
		private const string FILE_NAME = nameof(ButtonSettingParameterView);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(View) + SEPARATOR + FILE_NAME;

		[SerializeField] private Button _button;

		private void OnEnable() =>
			_button.onClick.AddListener(ApplyParameter);

		private void OnDisable() =>
			_button.onClick.RemoveListener(ApplyParameter);

		private void ApplyParameter() =>
			Parameter.Apply(!Parameter.CurrentValue);
	}
}