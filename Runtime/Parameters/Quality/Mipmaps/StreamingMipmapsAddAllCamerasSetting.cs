// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsAddAllCamerasSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.streamingMipmapsAddAllCameras;

		protected override void OnApply(bool value) => QualitySettings.streamingMipmapsAddAllCameras = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsAddAllCamerasSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsAddAllCamerasSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Mipmaps) + SLASH + FILE_NAME;
	}
}