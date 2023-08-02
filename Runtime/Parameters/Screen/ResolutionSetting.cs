// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Screen
{
	public sealed partial class ResolutionSetting : SettingsParameter<ResolutionSetting.SerializableResolution>
	{
		public override SerializableResolution CurrentValue =>
			UnityEngine.Screen.currentResolution;

		protected override void OnApply(SerializableResolution resolution) =>
			UnityEngine.Screen.SetResolution(resolution.Width, resolution.Height,
				UnityEngine.Screen.fullScreenMode, resolution.RefreshRate);

		[Serializable]
		public struct SerializableResolution
		{
			public static implicit operator SerializableResolution(Resolution self) =>
				new(self.width, self.height, self.refreshRateRatio);

			public static implicit operator Resolution(SerializableResolution self) => new()
			{
				width = self.Width,
				height = self.Height,
				refreshRateRatio = self.RefreshRate
			};

			/// <inheritdoc cref="Resolution.width"/>
			[field: SerializeField] public int Width { get; private set; }

			/// <inheritdoc cref="Resolution.height"/>
			[field: SerializeField] public int Height { get; private set; }

			/// <inheritdoc cref="Resolution.refreshRateRatio"/>
			public RefreshRate RefreshRate;

			public SerializableResolution(int width, int height, RefreshRate refreshRate)
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
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(Screen) + SEPARATOR + FILE_NAME;
	}
}