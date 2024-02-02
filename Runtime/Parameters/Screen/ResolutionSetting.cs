// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class ResolutionSetting : SettingsParameter<ResolutionSetting.SerializableResolution>
	{
		public override SerializableResolution CurrentValue => UnityEngine.Screen.currentResolution;

		protected override void OnApply(SerializableResolution resolution) =>
			UnityEngine.Screen.SetResolution(resolution.Width, resolution.Height,
				UnityEngine.Screen.fullScreenMode, resolution.RefreshRate);

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

			/// <inheritdoc cref="Resolution.width"/>
			[field: SerializeField] public int Width { get; private set; }

			/// <inheritdoc cref="Resolution.height"/>
			[field: SerializeField] public int Height { get; private set; }

			/// <inheritdoc cref="Resolution.refreshRate"/>
			public int RefreshRate;

			public SerializableResolution(int width, int height, int refreshRate)
			{
				Width = width;
				Height = height;
				RefreshRate = refreshRate;
			}

			/// <inheritdoc cref="Resolution.ToString"/>
			public override string ToString() => $"{Width} x {Height} @ {RefreshRate}Hz";
		}
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ResolutionSetting
	{
		private const string FILE_NAME = nameof(ResolutionSetting);
		private const string MENU_NAME = MENU_PATH + SLASH + nameof(Screen) + SLASH + FILE_NAME;
	}
}