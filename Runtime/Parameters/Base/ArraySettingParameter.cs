// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using System.Collections.ObjectModel;

namespace Depra.Settings.Parameters.Base
{
    public abstract class ArraySettingParameter<TValue> : SettingsParameter<int>
    {
        public TValue this[int index] => All[index];

        public override int CurrentValue => Array.IndexOf(All, Current);

        public ReadOnlyCollection<TValue> AllValues => Array.AsReadOnly(All);

        protected abstract TValue[] All { get; }

        protected abstract TValue Current { get; set; }

        protected override void OnApply(int index) => Current = All[index];
    }
}