// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Mipmaps
{
	public sealed partial class StreamingMipmapsActiveSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.streamingMipmapsActive;

		protected override void OnApply(bool value) => QualitySettings.streamingMipmapsActive = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class StreamingMipmapsActiveSetting
	{
		private const string FILE_NAME = nameof(StreamingMipmapsActiveSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Mipmaps) + SLASH + FILE_NAME;
	}
}