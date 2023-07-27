using Depra.Settings.Unity.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.Audio;
using static Depra.Settings.Unity.Runtime.Common.Constants;

namespace Depra.Settings.Unity.Runtime.Parameters.Audio
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class VolumeSetting : SettingsParameter<float>
	{
		private const string FILE_NAME = nameof(VolumeSetting);
		private const string MENU_NAME = MODULE_PATH + "/" + nameof(Audio) + "/" + FILE_NAME;

		[SerializeField] private AudioMixer _audioMixer;
		[SerializeField] private string _exposedParameter;

		public override string Name =>
			$"Audio {(_audioMixer ? $"{_audioMixer.name} {_exposedParameter}" : "Unassigned")}";

		public override float CurrentValue
		{
			get
			{
				_audioMixer.GetFloat(_exposedParameter, out var volume);
				return volume;
			}
		}

		protected override void OnReload() =>
			_audioMixer.ClearFloat(_exposedParameter);

		protected override void OnApply(float volume) =>
			_audioMixer.SetFloat(_exposedParameter, volume);
	}
}