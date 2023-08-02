// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using UnityEngine.Audio;

namespace Depra.Settings.Runtime.Parameters.Audio
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