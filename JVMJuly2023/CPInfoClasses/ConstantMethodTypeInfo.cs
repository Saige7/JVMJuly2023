using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantMethodTypeInfo : CPInfo
    {
        ushort DescriptorIndex;

        public ConstantMethodTypeInfo(ushort descriptorIndex, byte tag) : base((Tag)tag, Tag.ConstantMethodType)
        {
            DescriptorIndex = descriptorIndex;
        }
    }
}
