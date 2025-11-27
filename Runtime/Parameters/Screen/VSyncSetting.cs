// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.ComponentModel;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Screen
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class VSyncSetting : OptionSettingsParameter<VSyncSetting.VSync>
	{
		private const string FILE_NAME = nameof(VSyncSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Quality) + "/" + nameof(Screen) + "/" + FILE_NAME;

		public override VSync CurrentValue => (VSync)QualitySettings.vSyncCount;

		protected override VSync[] Choices { get; } =
		{
			VSync.DONT_SYNC,
			VSync.EVERY_V_BLANK,
			VSync.EVERY_SECOND_V_BLANK,
		};

		protected override void OnApply(VSync value) => QualitySettings.vSyncCount = (int)value;

		protected override string ToDisplayName(VSync value)
		{
			var memberInfo = typeof(VSync).GetMember(value.ToString());
			var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : value.ToString();
		}

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