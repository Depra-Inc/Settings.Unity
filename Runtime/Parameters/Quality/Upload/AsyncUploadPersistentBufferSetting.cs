﻿// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Upload
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class AsyncUploadPersistentBufferSetting : SettingsParameter<bool>
	{
		private const string FILE_NAME = nameof(AsyncUploadPersistentBufferSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR + 
		                                 nameof(Upload) + SEPARATOR + FILE_NAME;

		public override bool CurrentValue =>
			QualitySettings.asyncUploadPersistentBuffer;

		protected override void OnApply(bool value) =>
			QualitySettings.asyncUploadPersistentBuffer = value;
	}
}