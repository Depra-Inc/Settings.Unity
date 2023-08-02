// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Upload
{
	public sealed partial class AsyncUploadBufferSizeSetting : SettingsParameter<int>
	{
		private const int MIN = 2;
		private const int MAX = 2047;

		public override int CurrentValue =>
			QualitySettings.asyncUploadBufferSize;

		protected override void OnApply(int value) =>
			QualitySettings.asyncUploadBufferSize = Mathf.Clamp(value, MIN, MAX);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class AsyncUploadBufferSizeSetting
	{
		private const string FILE_NAME = nameof(AsyncUploadBufferSizeSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Upload) + SEPARATOR + FILE_NAME;
	}
}