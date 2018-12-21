using DevSecrets.Library;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace JsonStorage.Console
{
	public class MyJsonBlobStorage : JsonBlobStorage
	{
		protected override CloudBlobContainer GetContainer()
		{
			var config = DevSecretsDictionary.Load("JsonStorage.sln");
			var creds = new StorageCredentials(config.Contents["accountname"], config.Contents["accountkey"]);
			var account = new CloudStorageAccount(creds, true);
			var client = account.CreateCloudBlobClient();
			var container = client.GetContainerReference("jsonstorage");
			container.CreateIfNotExists();
			return container;
		}
	}
}