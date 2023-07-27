using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.Parameters.Display
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
    public sealed class AnisotropicFilteringSetting : SettingsParameter<AnisotropicFiltering>
    {
        private const string FILE_NAME = nameof(AnisotropicFilteringSetting);
        private const string MENU_NAME = MODULE_PATH + "/" + nameof(Display) + "/" + FILE_NAME;
        
        public override string Name => "Anisotropic Filtering";

        public override AnisotropicFiltering CurrentValue =>
            QualitySettings.anisotropicFiltering;

        protected override void OnApply(AnisotropicFiltering value) =>
            QualitySettings.anisotropicFiltering = value;
    }
}