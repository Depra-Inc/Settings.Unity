// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsRenderersPerFrameSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min = 1;

		public override int CurrentValue => QualitySettings.streamingMipmapsRenderersPerFrame;

		protected override void OnApply(int value) =>
			QualitySettings.streamingMipmapsRenderersPerFrame = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsRenderersPerFrameSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsRenderersPerFrameSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Mipmaps) + SLASH + FILE_NAME;
	}
}