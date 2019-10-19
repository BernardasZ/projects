using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.Models
{
    public class EditableFeatureView
    {
        public int FormId { get; set; }
        public int FeatureId { get; set; }
        public int? FeatureClassifierId { get; set; }
        public int? ClassifierTypeId { get; set; }
        public int? ClassifierId { get; set; }
        public string FeatureName { get; set; }
        public string ClassifierValue { get; set; }
    }
}
