// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Render
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class RealtimeReflectionProbesSetting : SettingsParameter<bool>
	{
		private const string FILE_NAME = nameof(RealtimeReflectionProbesSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Render) + SEPARATOR + FILE_NAME;

		public override bool CurrentValue =>
			QualitySettings.realtimeReflectionProbes;

		protected override void OnApply(bool value) =>
			QualitySettings.realtimeReflectionProbes = value;
	}
}