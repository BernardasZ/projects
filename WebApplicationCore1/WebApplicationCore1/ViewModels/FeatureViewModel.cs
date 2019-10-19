using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCore1.ViewModels
{
    public class FeatureViewModel
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public int? FeatureValue { get; set; }
        public IEnumerable<Classifier> FeatureClassifier { get; set; } = new List<Classifier>();
    }
}
