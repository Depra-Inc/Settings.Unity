// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using UnityEngine;

namespace Depra.Settings.Unity.Runtime.Save
{
	public sealed class PlayerPrefsSaveService : ISaveService
	{
		bool ISaveService.HasKey(string key) => PlayerPrefs.HasKey(key);

		void ISaveService.Save(string key, object value, Type type)
		{
			if (type == typeof(string))
			{
				PlayerPrefs.SetString(key, (string) value);
			}
			else if (type == typeof(int))
			{
				PlayerPrefs.SetInt(key, (int) value);
			}
			else if (type == typeof(float))
			{
				PlayerPrefs.SetFloat(key, (float) value);
			}
			else
			{
				PlayerPrefs.SetString(key, value.ToString());
			}

			PlayerPrefs.Save();
		}

		object ISaveService.Load(string key, Type type)
		{
			if (type == typeof(string))
			{
				return PlayerPrefs.GetString(key);
			}

			if (type == typeof(int))
			{
				return PlayerPrefs.GetInt(key);
			}

			if (type == typeof(float))
			{
				return PlayerPrefs.GetFloat(key);
			}

			return PlayerPrefs.GetString(key);
		}
	}
}