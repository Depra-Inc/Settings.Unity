// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsRenderersPerFrameSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min = 1;

		public override int CurrentValue =>
			QualitySettings.streamingMipmapsRenderersPerFrame;

		protected override void OnApply(int value) =>
			QualitySettings.streamingMipmapsRenderersPerFrame = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsRenderersPerFrameSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsRenderersPerFrameSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;
	}
}