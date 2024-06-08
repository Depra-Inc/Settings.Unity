// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Mipmaps
{
	public sealed partial class TextureMipmapLimitSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min;

		public override int CurrentValue =>
#if UNITY_2022_1_OR_NEWER
			QualitySettings.globalTextureMipmapLimit;
#else
			QualitySettings.masterTextureLimit;
#endif

		protected override void OnApply(int value) =>
#if UNITY_2022_1_OR_NEWER
			QualitySettings.globalTextureMipmapLimit =
#else
			QualitySettings.masterTextureLimit =
#endif
				Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class TextureMipmapLimitSetting
	{
		private const string FILE_NAME = nameof(TextureMipmapLimitSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Mipmaps) + SLASH + FILE_NAME;
	}
}