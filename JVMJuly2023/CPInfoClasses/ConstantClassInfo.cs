using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantClassInfo : CPInfo
    {
        ushort NameIndex;

        public ConstantClassInfo(ushort nameindex, byte tag) : base((Tag)tag, Tag.ConstantClass)
        {
            NameIndex = nameindex;
        }
    }
}
