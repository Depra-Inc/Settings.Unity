// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Render
{
	public sealed partial class PixelLightCountSetting : SettingsParameter<int>
	{
		[SerializeField] private int _min;

		public override int CurrentValue => QualitySettings.pixelLightCount;

		protected override void OnApply(int value) => QualitySettings.pixelLightCount = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class PixelLightCountSetting
	{
		private const string FILE_NAME = nameof(PixelLightCountSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Render) + SLASH + FILE_NAME;
	}
}