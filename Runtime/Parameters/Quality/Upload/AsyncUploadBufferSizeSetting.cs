// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Upload
{
	public sealed partial class AsyncUploadBufferSizeSetting : SettingsParameter<int>
	{
		private const int MIN = 2;
		private const int MAX = 2047;

		public override int CurrentValue => QualitySettings.asyncUploadBufferSize;

		protected override void OnApply(int value) =>
			QualitySettings.asyncUploadBufferSize = Mathf.Clamp(value, MIN, MAX);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class AsyncUploadBufferSizeSetting
	{
		private const string FILE_NAME = nameof(AsyncUploadBufferSizeSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Upload) + SLASH + FILE_NAME;
	}
}