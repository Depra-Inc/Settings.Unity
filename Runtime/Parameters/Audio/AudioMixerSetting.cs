// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Audio;
using static Depra.Settings.Runtime.Common.Module;

namespace Depra.Settings.Runtime.Parameters.Audio
{
	public sealed partial class AudioMixerSetting : SettingsParameter<float>
	{
		[SerializeField] private AudioMixer _audioMixer;
		[SerializeField] private string _exposedParameter;

		public override float CurrentValue =>
			_audioMixer.EnsureFloat(_exposedParameter);

		protected override string DefaultName =>
			$"Audio {(_audioMixer ? $"{_audioMixer.name} {_exposedParameter}" : "Unassigned")}";

		protected override void OnReload() =>
			_audioMixer.ClearFloat(_exposedParameter);

		protected override void OnApply(float volume) =>
			_audioMixer.SetFloat(_exposedParameter, volume);
	}

	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed partial class AudioMixerSetting
	{
		private const string FILE_NAME = nameof(AudioMixerSetting);
		private const string MENU_NAME = MODULE_PATH + SEPARATOR + nameof(Audio) + SEPARATOR + FILE_NAME;
	}
}