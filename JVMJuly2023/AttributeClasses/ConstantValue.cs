using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    class ConstantValue : AttributeInfo
    {
        public ushort ConstantValueIndex;

        public ConstantValue(ushort attributeNameIndex, uint attributeLength, ushort constantValuendex) : base(attributeNameIndex, attributeLength)
        {
            ConstantValueIndex = constantValuendex;
        }
    }
}
