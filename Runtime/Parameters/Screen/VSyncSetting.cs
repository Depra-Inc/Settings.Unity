// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System.ComponentModel;
using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	public sealed partial class VSyncSetting : SettingsParameter<VSyncSetting.VSync>
	{
		public override VSync CurrentValue => (VSync) QualitySettings.vSyncCount;

		protected override void OnApply(VSync value) => QualitySettings.vSyncCount = (int) value;

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

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class VSyncSetting
	{
		private const string FILE_NAME = nameof(VSyncSetting);

		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH +
		                                 nameof(Screen) + SLASH + FILE_NAME;
	}
}