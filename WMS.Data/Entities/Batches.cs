﻿using System;
using System.Collections.Generic;

namespace WMS.Data.Entities
{
    public partial class Batches
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Volume { get; set; }
        public int? VolumeUomId { get; set; }
        public string SubmittedBy { get; set; }
        public int? Vintage { get; set; }
        public int? VarietyId { get; set; }
        public int? TargetId { get; set; }
        public int? RecipeId { get; set; }
        public bool? Complete { get; set; }

        public virtual Recipes Recipe { get; set; }
        public virtual Targets Target { get; set; }
        public virtual Varieties Variety { get; set; }
        public virtual UnitsOfMeasure VolumeUom { get; set; }
    }
}
