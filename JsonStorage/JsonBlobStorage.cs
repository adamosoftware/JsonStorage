﻿using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace JsonStorage
{
	public abstract class JsonBlobStorage
	{
		protected abstract CloudBlobContainer GetContainer();

		/// <summary>
		/// Override this to modify the key as needed to inject any context you might need.
		/// Result must be URI-compliant since it will be a blob name
		/// </summary>
		protected virtual string GetBlobKey(string key)
		{
			return key;
		}

		public void Set(string key, object @object)
		{
			string json = JsonConvert.SerializeObject(@object);
			var blob = GetBlobInner(key);
			blob.UploadText(json);
		}

		public async Task SetAsync<T>(string key, T @object)
		{
			string json = JsonConvert.SerializeObject(@object);
			var blob = GetBlobInner(key);
			await blob.UploadTextAsync(json);
		}

		private CloudBlockBlob GetBlobInner(string key)
		{
			var container = GetContainer();
			var result = container.GetBlockBlobReference(GetBlobKey(key));
			result.Properties.ContentType = "text/json";
			return result;
		}

		public T Get<T>(string key, T defaultValue = default(T))
		{
			var blob = GetBlobInner(key);

			if (!blob.Exists()) return defaultValue;

			using (var stream = blob.OpenRead())
			{
				using (var reader = new StreamReader(stream))
				{
					string json = reader.ReadToEnd();
					return JsonConvert.DeserializeObject<T>(json);
				}
			}
		}

		public async Task<T> GetAsync<T>(string key, T defaultValue = default(T))
		{
			var blob = GetBlobInner(key);

			if (!blob.Exists()) return defaultValue;

			using (var stream = blob.OpenRead())
			{
				using (var reader = new StreamReader(stream))
				{
					string json = await reader.ReadToEndAsync();
					return JsonConvert.DeserializeObject<T>(json);
				}
			}
		}
	}
}