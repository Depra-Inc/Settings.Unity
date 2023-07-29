﻿// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Shadows
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class ShadowCascade2SplitSetting : SettingsParameter<float>
	{
		private const string FILE_NAME = nameof(ShadowCascade2SplitSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + 
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Shadows) + SEPARATOR + FILE_NAME;

		[SerializeField] private float _min;
		[SerializeField] private float _max = 1f;

		public override float CurrentValue =>
			QualitySettings.shadowCascade2Split;

		protected override void OnApply(float value) => 
			QualitySettings.shadowCascade2Split = Mathf.Clamp(value, _min, _max);
	}
}