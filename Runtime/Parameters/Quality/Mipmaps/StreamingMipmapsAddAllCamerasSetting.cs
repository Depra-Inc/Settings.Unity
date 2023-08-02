// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsAddAllCamerasSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue =>
			QualitySettings.streamingMipmapsAddAllCameras;

		protected override void OnApply(bool value) =>
			QualitySettings.streamingMipmapsAddAllCameras = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsAddAllCamerasSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsAddAllCamerasSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;
	}
}