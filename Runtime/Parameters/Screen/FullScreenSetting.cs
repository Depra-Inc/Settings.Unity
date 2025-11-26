// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class FullScreenSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue
		{
			get
			{
#if UNITY_EDITOR
				return EditorScreenAdapter.fullScreen;
#endif
				return UnityEngine.Screen.fullScreen;
			}
		}

		protected override void OnApply(bool value)
		{
			UnityEngine.Screen.fullScreen = value;
#if UNITY_EDITOR
			EditorScreenAdapter.fullScreen = value;
#endif
		}

#if UNITY_EDITOR
		internal static class EditorScreenAdapter
		{
			// ReSharper disable once InconsistentNaming
			public static bool fullScreen
			{
				get
				{
					var gameViewType = Type.GetType("UnityEditor.GameView,UnityEditor");
					var gameView = UnityEditor.EditorWindow.GetWindow(gameViewType, false, null, false);
					if (gameView == null)
					{
						throw new InvalidOperationException("GameView window not found.");
					}

					var maximizedProperty = gameViewType!.GetProperty("maximized");
					return (bool)maximizedProperty!.GetValue(gameView);
				}
				set
				{
					var gameViewType = Type.GetType("UnityEditor.GameView,UnityEditor");
					var gameView = UnityEditor.EditorWindow.GetWindow(gameViewType, false, null, false);
					if (gameView == null)
					{
						return;
					}

					var maximizedProperty = gameViewType!.GetProperty("maximized");
					if (maximizedProperty != null)
					{
						maximizedProperty.SetValue(gameView, value);
					}
				}
			}
		}
#endif
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class FullScreenSetting
	{
		private const string FILE_NAME = nameof(FullScreenSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Screen) + SLASH + FILE_NAME;
	}
}