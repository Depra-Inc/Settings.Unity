// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Settings.Runtime.Delegates
{
    public delegate void SettingValueChanged(object value);

    public delegate void SettingValueChanged<in TValue>(TValue value);
}