﻿// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsMaxFileIORequestsSetting : SettingsParameter<int>
	{
		public override int CurrentValue => QualitySettings.streamingMipmapsMaxFileIORequests;

		protected override void OnApply(int value) => QualitySettings.streamingMipmapsMaxFileIORequests = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsMaxFileIORequestsSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsMaxFileIORequestsSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Mipmaps) + SLASH + FILE_NAME;
	}
}