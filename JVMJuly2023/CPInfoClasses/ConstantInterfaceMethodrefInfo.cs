using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantInterfaceMethodrefInfo : CPInfo
    {
        ushort ClassIndex;
        ushort NameAndTypeIndex;

        public ConstantInterfaceMethodrefInfo(ushort classIndex, ushort nameAndTypeIndex, byte tag) : base((Tag)tag, Tag.ConstantInterfaceMethodref)
        {
            ClassIndex = classIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }
    }
}
