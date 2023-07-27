namespace Depra.Settings.Unity.Runtime.Delegates
{
    public delegate void SettingValueChangedDelegate(object value);

    public delegate void SettingValueChangedDelegate<in TValue>(TValue value);
}