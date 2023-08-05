using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023
{
    public class AttributeInfo
    {
        public ushort AttributeNameIndex;
        public uint AttributeLength;

        public AttributeInfo(ushort attributeNameIndex, uint attributeLength)
        {
            AttributeNameIndex = attributeNameIndex;
            AttributeLength = attributeLength;
        }
    }
}
