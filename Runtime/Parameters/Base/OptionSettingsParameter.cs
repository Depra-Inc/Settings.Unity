// SPDX-License-Identifier: Apache-2.0
// © 2023-2025 Depra <n.melnikov@depra.org>

using System;

namespace Depra.Settings.Parameters
{
	public abstract class OptionSettingsParameter<TValueChoice> : SettingsParameter<TValueChoice>,
		IOptionSettingParameter
	{
		public int Count => Choices.Length;

		public int CurrentIndex
		{
			get => Array.IndexOf(Choices, CurrentValue);
			set => Apply(Choices[value]);
		}

		protected abstract TValueChoice[] Choices { get; }

		public void ApplyIndex(int index) => Apply(Choices[index]);
		public string GetDisplayName(int index) => ToDisplayName(Choices[index]);

		protected abstract string ToDisplayName(TValueChoice value);
	}

	public interface IOptionSettingParameter : ISettingsParameter
	{
		int Count { get; }
		int CurrentIndex { get; set; }

		void ApplyIndex(int index);
		string GetDisplayName(int index);
	}
}