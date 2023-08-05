using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantFloatInfo : CPInfo
    {
        uint Bytes;

        public ConstantFloatInfo(uint bytes, byte tag) : base((Tag)tag, Tag.ConstantFloat)
        {
            Bytes = bytes;
        }
    }
}
