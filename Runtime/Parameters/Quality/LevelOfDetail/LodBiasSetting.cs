// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.LevelOfDetail
{
	public sealed partial class LodBiasSetting : SettingsParameter<float>
	{
		[Min(0f)] [SerializeField] private float _minValue = 0.01f;

		public override float CurrentValue => QualitySettings.lodBias;

		protected override void OnApply(float value) =>
			QualitySettings.lodBias = Mathf.Max(value, _minValue);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class LodBiasSetting
	{
		private const string FILE_NAME = nameof(LodBiasSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(LevelOfDetail) + SEPARATOR + FILE_NAME;
	}
}