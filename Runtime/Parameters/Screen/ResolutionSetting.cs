// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.Parameters.Screen
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = 51)]
    internal sealed class ResolutionSetting : SettingsParameter<Resolution>
    {
        private const string FILE_NAME = nameof(ResolutionSetting);
        private const string MENU_NAME = MODULE_PATH + "/" + nameof(Screen) + "/" + FILE_NAME;

        [SerializeField] private Resolution[] _resolutions;
        
        public override string Name => nameof(Resolution);

        public override Resolution CurrentValue => 
            UnityEngine.Screen.currentResolution;

        protected override void OnReload() =>
            OnApply(DefaultValue);

        protected override void OnApply(Resolution resolution) =>
            UnityEngine.Screen.SetResolution(resolution.width, resolution.height,
                UnityEngine.Screen.fullScreenMode, resolution.refreshRateRatio);
    }
}