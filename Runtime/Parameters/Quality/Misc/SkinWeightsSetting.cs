// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Depra.Settings.Module;

namespace Depra.Settings.Parameters.Quality
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class SkinWeightsSetting : ArraySettingParameter<string>
	{
		private const string FILE_NAME = nameof(SkinWeightsSetting);
		private const string MENU_NAME = MENU_PATH + nameof(Quality) + SLASH + nameof(Misc) + SLASH + FILE_NAME;
		private static readonly Dictionary<int, string> CHOICES = new()
		{
			{ (int)SkinWeights.None, nameof(SkinWeights.None) },
			{ (int)SkinWeights.OneBone, nameof(SkinWeights.OneBone) },
			{ (int)SkinWeights.TwoBones, nameof(SkinWeights.TwoBones) },
			{ (int)SkinWeights.FourBones, nameof(SkinWeights.FourBones) },
			{ (int)SkinWeights.Unlimited, nameof(SkinWeights.Unlimited) }
		};

		protected override string[] All => CHOICES.Values.ToArray();

		protected override string Current
		{
			get => CHOICES[(int)QualitySettings.skinWeights];
			set => QualitySettings.skinWeights = (SkinWeights)CHOICES.First(pair => pair.Value == value).Key;
		}
	}
}