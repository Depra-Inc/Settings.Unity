// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using System;
using Depra.Settings.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Common.Module;

namespace Depra.Settings.Parameters.Quality.Misc
{
	public sealed partial class QualityLevelSetting : ArraySettingParameter<string>
	{
		[SerializeField] private bool _applyExpensiveChanges;

		protected override string[] All => QualitySettings.names;

		protected override string Current
		{
			get => QualitySettings.names[QualitySettings.GetQualityLevel()];
			set => QualitySettings.SetQualityLevel(Array.IndexOf(All, value), _applyExpensiveChanges);
		}
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class QualityLevelSetting
	{
		private const string FILE_NAME = nameof(QualityLevelSetting);
		private const string MENU_NAME = MENU_PATH + SLASH +
		                                 nameof(Quality) + SLASH +
		                                 nameof(Misc) + SLASH + FILE_NAME;
	}
}