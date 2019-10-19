using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
	public class Classifier
	{
		public int? Id { get; set; }
		public int? ClassifierTypeId { get; set; }
		public string Value { get; set; }
	}
}