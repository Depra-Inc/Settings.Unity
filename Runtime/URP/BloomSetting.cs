using Depra.Settings.Parameters;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static Depra.Settings.Module;

namespace Depra.Settings.URP.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class BloomSetting : SettingsParameter<bool>
	{
		[SerializeField] private VolumeProfile[] _profiles;

		private const string FILE_NAME = "Bloom URP";
		private const string MENU_NAME = MENU_PATH + nameof(URP) + "/" + FILE_NAME;

		private bool _enabled;

		public override bool CurrentValue => _enabled;

		protected override void OnApply(bool value)
		{
			_enabled = value;
			foreach (var profile in _profiles)
			{
				if (profile.TryGet<Bloom>(out var bloom))
				{
					bloom.active = value;
				}
			}
		}
	}
}