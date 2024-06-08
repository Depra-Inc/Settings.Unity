using Depra.Settings.Parameters.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Depra.Settings.Parameters.External
{
	public abstract class ExternalSetting<TValue> : SettingsParameter<TValue>
	{
		[SerializeField] private UnityEvent<TValue> _onValueChanged;
		private TValue _value;

		public override TValue CurrentValue => _value;

		protected override void OnApply(TValue value) => _onValueChanged.Invoke(_value = value);
	}
}