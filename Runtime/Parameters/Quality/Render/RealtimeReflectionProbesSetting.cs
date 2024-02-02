﻿// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Render
{
	public sealed partial class RealtimeReflectionProbesSetting : SettingsParameter<bool>
	{
		public override bool CurrentValue => QualitySettings.realtimeReflectionProbes;

		protected override void OnApply(bool value) => QualitySettings.realtimeReflectionProbes = value;
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class RealtimeReflectionProbesSetting
	{
		private const string FILE_NAME = nameof(RealtimeReflectionProbesSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Render) + SLASH + FILE_NAME;
	}
}