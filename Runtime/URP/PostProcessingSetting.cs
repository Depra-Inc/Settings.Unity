using Depra.Settings.Parameters;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Depra.Settings.URP.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = Module.DEFAULT_ORDER)]
	public sealed class PostProcessingSetting : SettingsParameter<bool>
	{
		private const string FILE_NAME = "Post Processing URP";
		private const string MENU_NAME = Module.MENU_PATH + nameof(URP) + "/" + FILE_NAME;

		public override bool CurrentValue => GetCurrentValue();

		protected override void OnApply(bool value)
		{
			var camera = Camera.main;
			if (camera)
			{
				camera.GetUniversalAdditionalCameraData().renderPostProcessing = value;
			}
		}

		private static bool GetCurrentValue()
		{
			var camera = Camera.main;
			return camera != null && camera.GetUniversalAdditionalCameraData().renderPostProcessing;
		}
	}
}