// Copyright © 2023 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Settings.Persistent.Runtime;
using Depra.Settings.Runtime.Parameters.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Depra.Settings.Samples.Sources
{
	internal sealed class SettingsSaveExample : MonoBehaviour
	{
		[SerializeField] private SettingsPreset _preset;
		[SerializeField] private Button _saveButton;
		[SerializeField] private Button _loadButton;

		private SettingsSaveService _settingsSave;

		private void Start()
		{
			var storage = new DebugPersistentStorage();
			_settingsSave = new SettingsSaveService(storage, _preset.Parameters);
		}

		private void OnEnable()
		{
			_saveButton.onClick.AddListener(OnSaveButtonClick);
			_loadButton.onClick.AddListener(OnLoadButtonClick);
		}

		private void OnDisable()
		{
			_saveButton.onClick.RemoveListener(OnSaveButtonClick);
			_loadButton.onClick.RemoveListener(OnLoadButtonClick);
		}

		private void OnSaveButtonClick() => _settingsSave.SaveAll();

		private void OnLoadButtonClick() => _settingsSave.LoadAll();
	}
}