using System.Collections.ObjectModel;

namespace Depra.Settings.Unity.Runtime.Parameters.Base
{
    public abstract class ArraySettingParameter<TValue> : SettingsParameter<int>
    {
        public TValue this[int index] => Array[index];

        public override int CurrentValue =>
            System.Array.IndexOf(Array, Current);

        public ReadOnlyCollection<TValue> Collection =>
            System.Array.AsReadOnly(Array);

        protected abstract TValue[] Array { get; }

        protected abstract TValue Current { get; set; }

        protected override void OnApply(int index) =>
            Current = Array[index];
    }
}