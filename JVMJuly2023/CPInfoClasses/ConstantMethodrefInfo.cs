using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantMethodrefInfo : CPInfo
    {
        ushort ClassIndex;
        ushort NameAndTypeIndex;

        public ConstantMethodrefInfo(ushort classIndex, ushort nameAndTypeIndex, byte tag) : base((Tag)tag, Tag.ConstantMethodref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }
    }
}
