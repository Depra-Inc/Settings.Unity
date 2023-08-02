// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Shadows
{
	public sealed partial class ShadowNearPlaneOffsetSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min;

		public override float CurrentValue =>
			QualitySettings.shadowNearPlaneOffset;

		protected override void OnApply(float value) =>
			QualitySettings.shadowNearPlaneOffset = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowNearPlaneOffsetSetting
	{
		private const string FILE_NAME = nameof(ShadowNearPlaneOffsetSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;
	}
}