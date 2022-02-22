﻿using System;

namespace Task1
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class TrackingPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public TrackingPropertyAttribute()
        {

        }
    }
}
