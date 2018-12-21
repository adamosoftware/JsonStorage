using DevSecrets.Library;
using JsonStorage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Tests
{
	public class MyJsonBlobStorage : JsonBlobStorage
	{
		protected override CloudBlobContainer GetContainer()
		{
			return MyContainer.GetContainer();
		}
	}	
}