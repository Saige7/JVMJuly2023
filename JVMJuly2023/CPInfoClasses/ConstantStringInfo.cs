using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantStringInfo : CPInfo
    {
        ushort StringIndex;

        public ConstantStringInfo(ushort stringIndex, byte tag) : base((Tag)tag, Tag.ConstantString)
        {
            StringIndex = stringIndex;
        }
    }
}
