﻿using System;

using System.Reflection;
using static System.Reflection.BindingFlags;

namespace Binding_Demo
{
    public class InventoryItem
    {
        [DGDisplay("Serial Number")]
        public string Serial_Number { get; set; } = "SN";

        public string Make { get; set; } = "mk";

        [DGDisplay]
        public string Model { get; set; } = "model";

        public string Deployed_To { get; set; } = "dt";

        public string Machine_Name { get; set; } = "mn";

        public string Conway_Tag { get; set; } = "ct";

        [DGDisplay]
        public string Status { get; set; } = "status";
        public string Notes { get; set; } = "notes";
        public string Name { get; set; } = "name";

        public InventoryItem() { }
        public InventoryItem(object anonymousObject)
        {
            //get the type of the argument
            var anonType = anonymousObject.GetType();

            //make sure it's an anonymous type
            if (anonType.Namespace != null) return;

            //loop through every public property and try to match it to the anonymous type
            foreach(var prop in GetType().GetProperties(Public | Instance))
            {
                //see if the anonymous type has a matching property (null does not pattern match)
                if (anonType.GetProperty(prop.Name) is PropertyInfo anonProp)
                {
                    //if we found matching properties, set the value! This will fail if there are
                    //properties with matching names that have different types.
                    prop.SetValue(this, anonProp.GetValue(anonymousObject));
                }
            }
        }
    }

    public class DGDisplayAttribute : Attribute
    {
        public string HeaderName { get; set; }
        public DGDisplayAttribute(string header = null) => HeaderName = header;
    }
}
