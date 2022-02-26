﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using System.Text.Json;

namespace Task1
{
    [Serializable]
    public class Logger
    {
        private string jsonFileName;

        public Logger(string jsonFileName)
        {
            if (string.IsNullOrEmpty(jsonFileName))
            {
                throw new ArgumentException();
            }

            this.jsonFileName = jsonFileName + ".json";
        }

        public void Tracker<T>(T obj)
        {
            List<string> infoToStore = CollectInfo(obj);

            if (infoToStore.Count() != 0)
            {
                using (var fs = File.Create(jsonFileName))
                {
                    JsonSerializer.SerializeAsync(fs, infoToStore);
                }
            }
        }

        private List<string> CollectInfo<T>(T obj)
        {
            var type = typeof(T);
            var memberInfo = type.GetMembers();
            List<string> trackingPropertyElements = new List<string>();

            var p = type.GetCustomAttribute<TrackingEntityAttribute>();

            if (p is not null)
            {
                var filteredMemberInfo = memberInfo
                    .Where(x => x.GetCustomAttribute<TrackingPropertyAttribute>() != null)
                    .Select(x => x)
                    .ToList();

                foreach (var item in filteredMemberInfo)
                {
                    var attribute = item.GetCustomAttribute<TrackingPropertyAttribute>();

                    trackingPropertyElements.Add($"{attribute.PropertyName ?? item.Name}: " +
                        $"{(item.MemberType == MemberTypes.Field ? ((FieldInfo)item).GetValue(obj) : ((PropertyInfo)item).GetValue(obj))}");
                }
            }
            return trackingPropertyElements;
        }
    }
}
