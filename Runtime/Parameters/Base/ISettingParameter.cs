using Depra.Settings.Unity.Runtime.Delegates;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
	public interface ISettingParameter<out TValue>
	{
		public event SettingValueChangedDelegate<TValue> ValueChanged;
        
		public TValue CurrentValue { get; }
	}
}