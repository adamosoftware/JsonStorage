using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Models;

namespace Tests
{
	[TestClass]
	public class AllTests
	{
		[TestMethod]
		public void SimpleSaveAndLoad()
		{
			var storage = new MyJsonBlobStorage();
			var sample = new SampleType() { Name = "Whatever", Date = new DateTime(2010, 1, 1), Flag = true };
			storage.Set("sample", sample);

			var test = storage.Get<SampleType>("sample");
			Assert.AreEqual(sample, test);
		}

		[TestMethod]
		public void UserDataSaveAndLoad()
		{
			var storage = new UserStorage("adamo");
			var sample = new SampleType() { Name = "Whatever", Date = new DateTime(2010, 1, 1), Flag = true };
			storage.Set("sample", sample);

			var test = storage.Get<SampleType>("sample");
			Assert.AreEqual(sample, test);
		}
	}
}