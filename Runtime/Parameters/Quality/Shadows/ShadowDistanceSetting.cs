// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Shadows
{
	public sealed partial class ShadowDistanceSetting : SettingsParameter<float>
	{
		[SerializeField] private float _min;

		public override float CurrentValue =>
			QualitySettings.shadowDistance;

		protected override void OnApply(float value) =>
			QualitySettings.shadowDistance = Mathf.Max(value, _min);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class ShadowDistanceSetting
	{
		private const string FILE_NAME = nameof(ShadowDistanceSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;
	}
}