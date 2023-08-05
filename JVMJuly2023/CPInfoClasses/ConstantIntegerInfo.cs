using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantIntegerInfo : CPInfo
    {
        uint Bytes;

        public ConstantIntegerInfo(uint bytes, byte tag) : base((Tag)tag, Tag.ConstantInteger)
        {
            Bytes = bytes;
        }
    }
}
