using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCore1.ViewModels
{
	public class RegPozViewModel
	{
        public int FormId { get; set; }
        public List<FeatureViewModel> FeatureList { get; set; } = new List<FeatureViewModel>();
        public List<DropDown> DropDowns { get; set; } = new List<DropDown>();
    }

    public class DropDown
    {
        public int? FeatureValue { get; set; }
        public string Text { get; set; }
    }
}