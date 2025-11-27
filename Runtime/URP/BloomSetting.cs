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
		[SerializeField] private VolumeProfile _profile;

		private const string FILE_NAME = nameof(BloomSetting);
		private const string MENU_NAME = MENU_PATH + nameof(URP) + "/" + FILE_NAME;

		public override bool CurrentValue => _profile.TryGet<Bloom>(out var bloom) && bloom.active;

		protected override void OnApply(bool value)
		{
			if (_profile.TryGet<Bloom>(out var bloom))
			{
				bloom.active = value;
			}
		}
	}
}