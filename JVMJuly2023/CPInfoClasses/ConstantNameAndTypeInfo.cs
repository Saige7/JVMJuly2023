using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantNameAndTypeInfo : CPInfo
    {
        ushort NameIndex;
        ushort DescriptorIndex;

        public ConstantNameAndTypeInfo(ushort nameIndex, ushort descriptorIndex, byte tag) : base((Tag)tag, Tag.ConstantNameAndType)
        {
            NameIndex = nameIndex;
            DescriptorIndex = descriptorIndex;
        }
    }
}
