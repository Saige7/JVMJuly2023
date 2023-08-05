using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantDoubleInfo : CPInfo
    {
        uint HighBytes;
        uint LowBytes;

        public ConstantDoubleInfo(uint highBytes, uint lowBytes, byte tag) : base((Tag)tag, Tag.ConstantDouble)
        {
            HighBytes = highBytes;
            LowBytes = lowBytes;
        }
    }
}
