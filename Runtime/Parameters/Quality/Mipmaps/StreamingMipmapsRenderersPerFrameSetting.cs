// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Mipmaps
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class StreamingMipmapsRenderersPerFrameSetting : SettingsParameter<int>
	{
		private const string FILE_NAME = nameof(StreamingMipmapsRenderersPerFrameSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;

		[SerializeField] private int _min = 1;

		public override int CurrentValue =>
			QualitySettings.streamingMipmapsRenderersPerFrame;

		protected override void OnApply(int value) =>
			QualitySettings.streamingMipmapsRenderersPerFrame = Mathf.Max(value, _min);
	}
}