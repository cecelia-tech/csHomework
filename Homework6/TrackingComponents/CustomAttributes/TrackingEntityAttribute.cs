using System;

namespace Task1
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class)]
    public class TrackingEntityAttribute : Attribute
    {
        public TrackingEntityAttribute()
        {
        }
    }
}
