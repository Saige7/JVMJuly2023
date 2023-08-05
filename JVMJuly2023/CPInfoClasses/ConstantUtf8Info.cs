using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.CPInfoClasses
{
    public class ConstantUtf8Info : CPInfo
    {
        public ushort Length;
        public byte[] Bytes;

        public ConstantUtf8Info(ushort length, byte[] bytes, byte tag) : base((Tag)tag, Tag.ConstantUtf8)
        {
            Length = length;
            Bytes = bytes;
        }
    }
}
