using System;

namespace Depra.Settings.Parameters
{
	public interface ISerializable
	{
		string ToString();
	}
	
	public interface ISettingConstraint<TValue>
	{
		TValue Clamp(TValue value);
	}

	[Serializable]
	public struct FloatRangeConstraint : ISettingConstraint<float>
	{
		public float Min;
		public float Max;

		public FloatRangeConstraint(float min, float max)
		{
			Min = min;
			Max = max;
		}

		float ISettingConstraint<float>.Clamp(float value)
		{
			if (value < Min)
			{
				return Min;
			}

			if (value > Max)
			{
				return Max;
			}

			return value;
		}
	}
}