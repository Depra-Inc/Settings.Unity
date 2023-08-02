// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Settings.Runtime.Delegates
{
    public delegate void SettingValueChangedDelegate(object value);

    public delegate void SettingValueChangedDelegate<in TValue>(TValue value);
}