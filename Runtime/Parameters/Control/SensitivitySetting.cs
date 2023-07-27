using Depra.Settings.Unity.Runtime.Parameters.Base;
using Depra.Settings.Unity.Runtime.Save;

namespace Depra.Settings.Unity.Runtime.Parameters.Control
{
    internal sealed class SensitivitySetting : SettingsParameter<float>
    {
        public override string Name { get; }
        public override float CurrentValue { get; }
        
        protected override void OnApply(float value)
        {
            
        }
    }

    public interface ISensitivityUser
    {
        float Sensitivity { get; set; }
    }
}