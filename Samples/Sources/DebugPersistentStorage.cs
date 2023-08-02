// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Persistent.Runtime;
using UnityEngine;

namespace Depra.Settings.Samples.Sources
{
	internal sealed class DebugPersistentStorage : IPersistentStorage
	{
		bool IPersistentStorage.HasKey(string key)
		{
			Debug.Log($"HasKey: {key}");
			return true;
		}

		void IPersistentStorage.Save(string key, IPersistent persistent) =>
			Debug.Log($"Save: {key} {persistent.CaptureState()} {persistent.StateType}");

		object IPersistentStorage.Load(string key, IPersistent persistent)
		{
			Debug.Log($"Load: {key} {persistent.StateType}");
			return persistent.CaptureState();
		}
	}
}