// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Settings.Unity.Runtime.Persistent
{
	internal interface IPersistent
	{
		object CaptureState();
        
		void RestoreState(object state);
	}
}