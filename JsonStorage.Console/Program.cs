using JsonStorage.Console.Models;

namespace JsonStorage.Console
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var storage = new MyJsonBlobStorage();
			//storage.Set("sample", new SampleType() { Greeting = "hello" });

			var sample = storage.Get<SampleType>("sample");
		}
	}
}