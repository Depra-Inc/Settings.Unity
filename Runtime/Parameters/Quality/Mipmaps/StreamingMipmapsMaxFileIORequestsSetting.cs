// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsMaxFileIORequestsSetting : SettingsParameter<int>
	{
		public override int CurrentValue =>
			QualitySettings.streamingMipmapsMaxFileIORequests;

		protected override void OnApply(int value) =>
			QualitySettings.streamingMipmapsMaxFileIORequests = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsMaxFileIORequestsSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsMaxFileIORequestsSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;
	}
}