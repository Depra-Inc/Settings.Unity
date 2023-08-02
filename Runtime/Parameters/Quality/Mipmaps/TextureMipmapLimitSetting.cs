// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Mipmaps
{
	public sealed partial class TextureMipmapLimitSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min;

		public override int CurrentValue =>
			QualitySettings.globalTextureMipmapLimit;

		protected override void OnApply(int value) =>
			QualitySettings.globalTextureMipmapLimit = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class TextureMipmapLimitSetting
	{
		private const string FILE_NAME = nameof(TextureMipmapLimitSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Mipmaps) + SEPARATOR + FILE_NAME;
	}
}