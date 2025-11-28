// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;
using System.Linq;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class SkinWeightsSetting : OptionSettingsParameter<SkinWeights>
	{
		private const string FILE_NAME = nameof(SkinWeightsSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Quality) + "/" + nameof(Misc) + "/" + FILE_NAME;

		public override SkinWeights CurrentValue => QualitySettings.skinWeights;

		protected override SkinWeights[] Choices => Enum.GetValues(typeof(SkinWeights)).Cast<SkinWeights>().ToArray();

		protected override void OnApply(SkinWeights value) => QualitySettings.skinWeights = value;

		protected override string ToDisplayName(SkinWeights value) => value.ToString();
	}
}