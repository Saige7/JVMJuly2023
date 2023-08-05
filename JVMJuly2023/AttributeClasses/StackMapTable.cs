using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    class StackMapTable : AttributeInfo
    {
        ushort numberOfEntries;

        public StackMapTable(ushort attributeNameIndex, uint attributeLength) : base(attributeNameIndex, attributeLength)
        {

        }
    }
}
