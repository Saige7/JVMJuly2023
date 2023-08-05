using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    class Synthetic : AttributeInfo
    {
        public Synthetic(ushort attributeNameIndex, uint attributeLength) : base(attributeNameIndex, attributeLength)
        {
        }
    }
}
