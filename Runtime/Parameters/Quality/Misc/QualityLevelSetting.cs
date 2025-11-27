// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality.Misc
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class QualityLevelSetting : ArraySettingParameter<string>
	{
		[SerializeField] private bool _applyExpensiveChanges;

		private const string FILE_NAME = nameof(QualityLevelSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Quality) + "/" + nameof(Misc) + "/" + FILE_NAME;

		protected override string[] All => QualitySettings.names;

		protected override string Current
		{
			get => QualitySettings.names[QualitySettings.GetQualityLevel()];
			set => QualitySettings.SetQualityLevel(Array.IndexOf(All, value), _applyExpensiveChanges);
		}
	}
}