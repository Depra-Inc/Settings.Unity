// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Upload
{
	public sealed partial class AsyncUploadPersistentBufferSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.asyncUploadPersistentBuffer;

		protected override void OnApply(bool value) => QualitySettings.asyncUploadPersistentBuffer = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class AsyncUploadPersistentBufferSetting
	{
		private const string FILE_NAME = nameof(AsyncUploadPersistentBufferSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Upload) + SLASH + FILE_NAME;
	}
}