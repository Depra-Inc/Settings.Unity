// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Depra.Settings.Parameters.Screen
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = Module.DEFAULT_ORDER)]
	public sealed class FullScreenModeSetting : ArraySettingParameter<string>
	{
		private const string FILE_NAME = nameof(FullScreenModeSetting);
		private const string MENU_NAME = Module.MENU_PATH + nameof(Screen) + Module.SLASH + FILE_NAME;

		private static readonly Dictionary<int, string> CHOICES = new()
		{
			{ (int)FullScreenMode.ExclusiveFullScreen, nameof(FullScreenMode.ExclusiveFullScreen) },
			{ (int)FullScreenMode.FullScreenWindow, nameof(FullScreenMode.FullScreenWindow) },
			{ (int)FullScreenMode.MaximizedWindow, nameof(FullScreenMode.MaximizedWindow) },
			{ (int)FullScreenMode.Windowed, nameof(FullScreenMode.Windowed) }
		};

		protected override string[] All => CHOICES.Values.ToArray();

		protected override string Current
		{
			get => CHOICES[(int)UnityEngine.Screen.fullScreenMode];
			set => UnityEngine.Screen.fullScreenMode = (FullScreenMode)CHOICES.First(pair => pair.Value == value).Key;
		}
	}
}