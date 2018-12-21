using System;

namespace Tests.Models
{
	public class SampleType
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public bool Flag { get; set; }

		public override bool Equals(object obj)
		{
			var test = obj as SampleType;
			if (test != null)
			{
				return Name.Equals(test.Name) && Date == test.Date && Flag == test.Flag;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}