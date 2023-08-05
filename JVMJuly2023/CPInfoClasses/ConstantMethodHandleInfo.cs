using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    class ConstantMethodHandleInfo : CPInfo
    {
        byte ReferenceKind;
        ushort ReferenceIndex;

        public ConstantMethodHandleInfo(byte referenceKind, ushort referenceIndex, byte tag) : base((Tag)tag, Tag.ConstantMethodHandle)
        {
            ReferenceKind = referenceKind;
            ReferenceIndex = referenceIndex;
        }
    }
}
