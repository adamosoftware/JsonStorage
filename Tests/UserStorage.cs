using JsonStorage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Tests
{
	/// <summary>
	/// A sample storage mechanism for users in a hypothethical web app
	/// </summary>
	public class UserStorage : JsonBlobStorage
	{
		private readonly string _userName;

		public UserStorage(string userName)
		{
			_userName = userName;
		}

		protected override string GetBlobKey(string key)
		{
			return _userName + "/" + key;
		}

		protected override CloudBlobContainer GetContainer()
		{
			return MyContainer.GetContainer();
		}
	}
}