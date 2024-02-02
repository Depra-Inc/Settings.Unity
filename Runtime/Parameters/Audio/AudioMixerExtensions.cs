// SPDX-License-Identifier: Apache-2.0
// © 2023-2024 Nikolay Melnikov <n.melnikov@depra.org>

using UnityEngine.Audio;

namespace Depra.Settings.Parameters.Audio
{
	internal static class AudioMixerExtensions
	{
		public static float EnsureFloat(this AudioMixer self, string exposedParameter)
		{
			self.GetFloat(exposedParameter, out var value);
			return value;
		}
	}
}