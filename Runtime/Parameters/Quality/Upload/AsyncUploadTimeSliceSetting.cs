// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Upload
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class AsyncUploadTimeSliceSetting : SettingsParameter<int>
	{
		private const string FILE_NAME = nameof(AsyncUploadTimeSliceSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR + 
		                                 nameof(Upload) + SEPARATOR + FILE_NAME;

		[SerializeField] private int _min = 1;
		[SerializeField] private int _max = 33;

		public override int CurrentValue =>
			QualitySettings.asyncUploadTimeSlice;

		protected override void OnApply(int value) =>
			QualitySettings.asyncUploadTimeSlice = Mathf.Clamp(value, _min, _max);
	}
}