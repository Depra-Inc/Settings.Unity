// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Settings.Runtime.Common
{
    internal static class Module
    {
        public const string ENGINE_NAME = "Unity";
        public const string MODULE_NAME = "Settings";
        private const string FRAMEWORK_NAME = "Depra";

        internal const int DEFAULT_ORDER = 51;
        internal const string SEPARATOR = "/";
        internal const string MODULE_PATH = FRAMEWORK_NAME + SEPARATOR + MODULE_NAME;
    }
}