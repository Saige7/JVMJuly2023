using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantLongInfo : CPInfo
    {
        uint HighBytes;
        uint LowBytes;

        public ConstantLongInfo(uint highBytes, uint lowBytes, byte tag) : base((Tag)tag, Tag.ConstantLong)
        {
            HighBytes = highBytes;
            LowBytes = lowBytes;
        }
    }
}
