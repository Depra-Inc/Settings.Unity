// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.ComponentModel;
using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Screen
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class VSyncSetting : SettingsParameter<VSyncSetting.VSync>
	{
		private const string FILE_NAME = nameof(VSyncSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Screen) + SEPARATOR + FILE_NAME;

		public override VSync CurrentValue =>
			(VSync) QualitySettings.vSyncCount;

		protected override void OnApply(VSync value) =>
			QualitySettings.vSyncCount = (int) value;

		/// <summary>
		/// VSync options.
		/// </summary>
		public enum VSync
		{
			/// <summary>
			/// No <see cref="VSync"/>, this is best in high action games.
			/// </summary>
			[Description("Don't Sync")]
			DONT_SYNC = 0,

			/// <summary>
			/// Sync the framerate to the framerate of your monitor.
			/// </summary>
			[Description("Every VBlank")]
			EVERY_V_BLANK = 1,

			/// <summary>
			/// Half the framerate of your monitor.
			/// </summary>
			[Description("Every Second VBlank")]
			EVERY_SECOND_V_BLANK = 2,
		}
	}
}