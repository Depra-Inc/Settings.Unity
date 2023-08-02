using System;
using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Quality.Misc
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
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Misc) + SEPARATOR + FILE_NAME;
	}
}