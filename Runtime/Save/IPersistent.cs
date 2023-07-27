namespace Depra.Settings.Unity.Runtime.Save
{
	internal interface IPersistent
	{
		object CaptureState();
        
		void RestoreState(object state);
	}
}