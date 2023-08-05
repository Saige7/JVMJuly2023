using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantFieldrefInfo : CPInfo
    {
        ushort ClassIndex;
        ushort NameAndTypeIndex;

        public ConstantFieldrefInfo(ushort classIndex, ushort nameAndTypeIndex, byte tag) : base((Tag)tag, Tag.ConstantFieldref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }
    }
}
