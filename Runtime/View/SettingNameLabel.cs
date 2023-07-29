using Depra.Settings.Unity.Runtime.Parameters.Base;
using TMPro;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.View
{
	[AddComponentMenu(menuName: MENU_NAME, order: DEFAULT_ORDER)]
	public sealed class SettingNameLabel : MonoBehaviour
	{
		private const string FILE_NAME = "Setting Name Label";
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(View) + SEPARATOR + FILE_NAME;

		[SerializeField] private TMP_Text _displayName;
		[SerializeField] private SettingsParameter _parameter;

		private void Start() => _displayName.text = _parameter.DisplayName;
	}
}