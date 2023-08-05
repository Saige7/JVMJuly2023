using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    public class SourceFile : AttributeInfo
    {
        public ushort SourceFileIndex;
        public SourceFile(ushort attributeNameIndex, uint attributeLength, byte[] Bytes, ref int currentIndex) : base(attributeNameIndex, attributeLength)
        {
            SourceFileIndex = (ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]);
            currentIndex += 2;
        }
    }
}
