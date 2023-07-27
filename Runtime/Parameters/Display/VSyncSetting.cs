// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.Parameters.Display
{
    [CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
    public sealed class VSyncSetting : SettingsParameter<VSyncSetting.VBlank>
    {
        private const string FILE_NAME = nameof(VSyncSetting);
        private const string MENU_NAME = MODULE_PATH + "/" + nameof(Display) + "/" + FILE_NAME;
        
        public override string Name => "VSync";

        public override VBlank CurrentValue =>
            (VBlank) QualitySettings.vSyncCount;

        protected override void OnApply(VBlank value) =>
            QualitySettings.vSyncCount = (int) value;

        public enum VBlank
        {
            DONT_SYNC,
            EVERY_V_BLANK,
            EVERY_SECOND_V_BLANK,
        }
    }
}