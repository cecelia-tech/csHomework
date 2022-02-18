using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
