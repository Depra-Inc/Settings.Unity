// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.ObjectModel;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
    public abstract class ArraySettingParameter<TValue> : SettingsParameter<int>
    {
        public TValue this[int index] => All[index];

        public override int CurrentValue =>
            System.Array.IndexOf(All, Current);

        public ReadOnlyCollection<TValue> AllValues =>
            System.Array.AsReadOnly(All);

        protected abstract TValue[] All { get; }

        protected abstract TValue Current { get; set; }

        protected override void OnApply(int index) =>
            Current = All[index];
    }
}