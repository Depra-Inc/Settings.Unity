using UnityEngine.Audio;

namespace Depra.Settings.Unity.Runtime.Parameters.Audio
{
	internal static class AudioMixerExtensions
	{
		public static float GetRequiredFloat(this AudioMixer self, string exposedParameter)
		{
			self.GetFloat(exposedParameter, out var value);
			return value;
		}
	}
}