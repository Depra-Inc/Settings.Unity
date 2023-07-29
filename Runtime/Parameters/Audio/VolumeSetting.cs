// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Audio;
using static Depra.Settings.Unity.Runtime.Common.Module;

namespace Depra.Settings.Unity.Runtime.Parameters.Audio
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class VolumeSetting : SettingsParameter<float>
	{
		private const string FILE_NAME = nameof(VolumeSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(Audio) + SEPARATOR + FILE_NAME;
		
		[SerializeField] private AudioMixer _audioMixer;
		[SerializeField] private string _exposedParameter;

		public override float CurrentValue =>
			_audioMixer.GetRequiredFloat(_exposedParameter);

		protected override string DefaultName =>
			$"Audio {(_audioMixer ? $"{_audioMixer.name} {_exposedParameter}" : "Unassigned")}";

		protected override void OnReload() =>
			_audioMixer.ClearFloat(_exposedParameter);

		protected override void OnApply(float volume) =>
			_audioMixer.SetFloat(_exposedParameter, volume);
	}
}