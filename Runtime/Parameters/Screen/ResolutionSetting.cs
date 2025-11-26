// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class ResolutionSetting : SettingsParameter<Vector2Int>
	{
		public override Vector2Int CurrentValue
		{
			get
			{
				var currentResolution = UnityEngine.Screen.currentResolution;
				return new Vector2Int(currentResolution.width, currentResolution.height);
			}
		}

		protected override void OnApply(Vector2Int resolution) =>
			UnityEngine.Screen.SetResolution(resolution.x, resolution.y, UnityEngine.Screen.fullScreenMode);

		[Serializable]
		public struct SerializableResolution
		{
			public static implicit operator SerializableResolution(Resolution self) =>
				new(self.width, self.height, self.refreshRate);

			public static implicit operator Resolution(SerializableResolution self) => new()
			{
				width = self.Width,
				height = self.Height,
				refreshRate = self.RefreshRate
			};

			public int Width;
			public int Height;
			public int RefreshRate;

			public SerializableResolution(int width, int height, int refreshRate)
			{
				Width = width;
				Height = height;
				RefreshRate = refreshRate;
			}

			public override string ToString() => $"{Width} x {Height} @ {RefreshRate}Hz";
		}
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ResolutionSetting
	{
		private const string FILE_NAME = nameof(ResolutionSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + SLASH + FILE_NAME;
	}
}