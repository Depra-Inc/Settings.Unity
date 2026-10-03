using Depra.Settings.Parameters;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Depra.Settings.Module;

namespace Depra.Settings.URP.Parameters
{
	[CreateAssetMenu(fileName = FILE_NAME, menuName = MENU_NAME, order = DEFAULT_ORDER)]
	public sealed class AntiAliasingSetting : OptionSettingsParameter<AntiAliasingSetting.AAFilteringOption>
	{
		private const string FILE_NAME = "Anti Aliasing URP";
		private const string MENU_NAME = MENU_PATH + nameof(URP) + "/" + FILE_NAME;

		public override AAFilteringOption CurrentValue => GetCurrentValue();

		protected override string DefaultName => FILE_NAME;

		protected override AAFilteringOption[] Choices { get; } =
		{
			AAFilteringOption.Disabled,
			AAFilteringOption.FAA,
			AAFilteringOption.SMAA,
			AAFilteringOption.TAA
		};

		protected override void OnApply(AAFilteringOption value)
		{
			var camera = Camera.main;
			if (!camera)
			{
				return;
			}

			camera.GetUniversalAdditionalCameraData().antialiasing = value switch
			{
				AAFilteringOption.FAA => AntialiasingMode.FastApproximateAntialiasing,
				AAFilteringOption.SMAA => AntialiasingMode.SubpixelMorphologicalAntiAliasing,
				AAFilteringOption.TAA => AntialiasingMode.TemporalAntiAliasing,
				_ => AntialiasingMode.None
			};
		}

		protected override string ToDisplayName(AAFilteringOption value) => value.ToString();

		private static AAFilteringOption GetCurrentValue()
		{
			var camera = Camera.main;
			if (camera == null)
			{
				return AAFilteringOption.Disabled;
			}

			return camera.GetUniversalAdditionalCameraData().antialiasing switch
			{
				AntialiasingMode.FastApproximateAntialiasing => AAFilteringOption.FAA,
				AntialiasingMode.SubpixelMorphologicalAntiAliasing => AAFilteringOption.SMAA,
				AntialiasingMode.TemporalAntiAliasing => AAFilteringOption.TAA,
				_ => AAFilteringOption.Disabled
			};
		}

		public enum AAFilteringOption
		{
			Disabled,
			FAA,
			SMAA,
			TAA
		}
	}
}