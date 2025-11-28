// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

namespace Depra.Settings
{
    public delegate void SettingValueChanged(object value);

    public delegate void SettingValueChanged<in TValue>(TValue value);
}