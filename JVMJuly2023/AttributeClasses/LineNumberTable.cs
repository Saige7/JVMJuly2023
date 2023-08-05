using JVMJuly2023.AttributeClassesHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    public class LineNumberTable : AttributeInfo
    {
        public ushort LineNumberTableLength;
        public lineNumberTable[] LineNumberTables;
        public LineNumberTable(ushort attributeNameIndex, uint attributeLength, byte[] Bytes, ref int currentIndex) : base(attributeNameIndex, attributeLength)
        {
            LineNumberTableLength = (ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]);
            currentIndex += 2;

            LineNumberTables = new lineNumberTable[LineNumberTableLength];
            for(int i = 0; i < LineNumberTableLength; i++)
            {
                lineNumberTable lineNumberTable = new lineNumberTable((ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]), 
                    (ushort)(Bytes[currentIndex + 2] << 8 | Bytes[currentIndex + 3]));
                currentIndex += 4;
                LineNumberTables[i] = lineNumberTable;
            }
        }
    }
}
