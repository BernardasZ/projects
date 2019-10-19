using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataModels.Models
{
	public class Feature
	{
        public int Id { get; set; }
		public int? ClassifierId { get; set; }
        public int FormId { get; set; }
        public string Name { get; set; }
	}
}