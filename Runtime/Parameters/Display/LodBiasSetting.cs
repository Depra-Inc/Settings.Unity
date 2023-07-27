using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.Parameters.Display
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
    public sealed class LodBiasSetting : SettingsParameter<float>
    {
        private const string FILE_NAME = nameof(LodBiasSetting);
        private const string MENU_NAME = MODULE_PATH + "/" + nameof(Display) + "/" + FILE_NAME;

        [Min(0f)] [SerializeField] private float _minValue = 0.01f;

        public override string Name => "Lod Bias";

        public override float CurrentValue => QualitySettings.lodBias;

        protected override void OnApply(float value) =>
            QualitySettings.lodBias = Mathf.Max(value, _minValue);
    }
}