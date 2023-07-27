// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;

namespace Depra.Settings.Unity.Runtime.Parameters.Control
{
    internal sealed class SensitivitySetting : SettingsParameter<float>
    {
        public override string Name { get; }
        public override float CurrentValue { get; }
        
        protected override void OnApply(float value)
        {
            
        }
        
        public interface ISensitivityUser
        {
            float Sensitivity { get; set; }
        }
    }
}