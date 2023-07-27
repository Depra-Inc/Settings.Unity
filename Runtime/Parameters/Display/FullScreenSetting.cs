using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.Parameters.Display
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
    public sealed class FullScreenSetting : SettingsParameter<bool>
    {
        private const string FILE_NAME = nameof(AnisotropicFilteringSetting);
        private const string MENU_NAME = MODULE_PATH + "/" + nameof(Display) + "/" + FILE_NAME;

        public override string Name => "Full Screen";

        public override bool CurrentValue =>
            UnityEngine.Screen.fullScreen;

        protected override void OnApply(bool value)
        {
            Debug.Log(value);
            UnityEngine.Screen.fullScreen = value;
        }
    }
}