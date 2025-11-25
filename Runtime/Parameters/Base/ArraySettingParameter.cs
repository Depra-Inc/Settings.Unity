// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Collections.ObjectModel;

namespace Depra.Settings.Parameters
{
    public abstract class ArraySettingParameter<TValueChoice> : SettingsParameter<int>
    {
        public override int CurrentValue => Array.IndexOf(All, Current);

        public ReadOnlyCollection<TValueChoice> AllValues => Array.AsReadOnly(All);

        protected abstract TValueChoice[] All { get; }

        protected abstract TValueChoice Current { get; set; }

        protected override void OnApply(int index) => Current = All[index];
    }
}