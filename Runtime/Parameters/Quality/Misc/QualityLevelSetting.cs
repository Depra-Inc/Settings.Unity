using System;
using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Quality.Misc
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class QualityLevelSetting : ArraySettingParameter<string>
	{
		private const string FILE_NAME = nameof(QualityLevelSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR +
		                                 nameof(Quality) + SEPARATOR +
		                                 nameof(Misc) + SEPARATOR + FILE_NAME;

		[SerializeField] private bool _applyExpensiveChanges;
		
		protected override string[] All => QualitySettings.names;

		protected override string Current
		{
			get => QualitySettings.names[QualitySettings.GetQualityLevel()];
			set => QualitySettings.SetQualityLevel(Array.IndexOf(All, value), _applyExpensiveChanges);
		}
	}
}