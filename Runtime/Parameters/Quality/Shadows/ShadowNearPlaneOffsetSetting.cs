// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Shadows
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ShadowNearPlaneOffsetSetting : SettingsParameter<float>
	{
		private const string FILE_NAME = nameof(ShadowNearPlaneOffsetSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;

		[SerializeField] private float _min;

		public override float CurrentValue =>
			QualitySettings.shadowNearPlaneOffset;

		protected override void OnApply(float value) =>
			QualitySettings.shadowNearPlaneOffset = Mathf.Max(value, _min);
	}
}