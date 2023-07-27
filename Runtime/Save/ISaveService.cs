using System;

namespace Depra.Settings.Unity.Runtime.Save
{
	public interface ISaveService
	{
		bool HasKey(string key);
		
		void Save(string key, object value, Type type);
		
		object Load(string key, Type type);
	}
}