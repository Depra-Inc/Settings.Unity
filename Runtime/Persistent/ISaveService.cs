// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;

namespace Depra.Settings.Unity.Runtime.Persistent
{
	public interface ISaveService
	{
		bool HasKey(string key);
		
		void Save(string key, object value, Type type);
		
		object Load(string key, Type type);
	}
}