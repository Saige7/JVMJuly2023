using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantInvokeDynamicInfo : CPInfo
    {
        ushort BootstrapMethodAttrIndex;
        ushort NameAndTypeIndex;

        public ConstantInvokeDynamicInfo(ushort bootstrapMethodAttrIndex, ushort nameAndTypeIndex, byte tag) : base((Tag)tag, Tag.ConstantInvokeDynamic)
        {
            BootstrapMethodAttrIndex = bootstrapMethodAttrIndex;
            NameAndTypeIndex = nameAndTypeIndex;
        }
    }
}
