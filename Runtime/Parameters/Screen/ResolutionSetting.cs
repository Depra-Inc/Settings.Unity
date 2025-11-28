// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ResolutionSetting : OptionSettingsParameter<ResolutionSetting.Resolution>
	{
		private const string FILE_NAME = "Resolution";
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + "/" + FILE_NAME;

		public override Resolution CurrentValue => UnityEngine.Screen.currentResolution;
		public override Resolution DefaultValue => UnityEngine.Screen.currentResolution;

		protected override Resolution[] Choices => Array.ConvertAll(
			UnityEngine.Screen.resolutions,
			resolution => (Resolution)resolution);

		protected override void OnApply(Resolution value) =>
			UnityEngine.Screen.SetResolution(value.Width, value.Height,
				UnityEngine.Screen.fullScreenMode, value.RefreshRateRatio);

		protected override string ToDisplayName(Resolution value) => value.ToString();

		[Serializable]
		public struct Resolution
		{
			public static implicit operator Resolution(UnityEngine.Resolution self) =>
				new(self.width, self.height, self.refreshRateRatio);

			public int Width;
			public int Height;
			public float RefreshRate;

			public Resolution(int width, int height, RefreshRate refreshRate)
			{
				Width = width;
				Height = height;
				RefreshRate = (int)Math.Round(refreshRate.value);
			}

			public RefreshRate RefreshRateRatio => new()
			{
				numerator = (uint)RefreshRate,
				denominator = 1U
			};

			public override string ToString() => $"{Width} x {Height} @ {RefreshRate}Hz";
		}
	}
}