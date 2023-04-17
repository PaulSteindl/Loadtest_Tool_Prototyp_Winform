using System;
using System.ComponentModel;

namespace Loadtest_Tool_Prototyp_Winform
{
    public class ExpandableTypeDescriptionProvider : TypeDescriptionProvider
    {
        public ExpandableTypeDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(object)))
        {
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return new ExpandableCustomTypeDescriptor(base.GetTypeDescriptor(objectType, instance));
        }

        private class ExpandableCustomTypeDescriptor : CustomTypeDescriptor
        {
            public ExpandableCustomTypeDescriptor(ICustomTypeDescriptor parent)
                : base(parent)
            {
            }

            public override TypeConverter GetConverter()
            {
                return new ExpandableObjectConverter();
            }
        }
    }
}