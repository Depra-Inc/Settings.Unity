// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

namespace Depra.Settings
{
    public delegate void SettingValueChanged(object value);

    public delegate void SettingValueChanged<in TValue>(TValue value);
}