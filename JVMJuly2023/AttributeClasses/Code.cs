using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    public class Code : AttributeInfo
    {
        public ushort MaxStack;
        public ushort MaxLocals;
        public uint CodeLength;
        public byte[] code;
        public ushort ExceptionTableLength;

        public ExceptionTable[] ExceptionTable;
        public ushort CodeAttributeCount;
        public AttributeInfo[] Attributes;
        public Code(ushort attributeNameIndex, uint attributeLength, byte[] Bytes, ref int currentIndex, CPInfo[] cpInfos) : base(attributeNameIndex, attributeLength)
        {
            MaxStack = (ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]);
            currentIndex += 2;
            MaxLocals = (ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]);
            currentIndex += 2;
            CodeLength = (uint)(Bytes[currentIndex] << 24 | Bytes[currentIndex + 1] << 16 | Bytes[currentIndex + 2] << 8 | Bytes[currentIndex + 3]);
            currentIndex += 4;
            code = new byte[CodeLength];
            for(int i = 0; i < CodeLength; i++)
            {
                code[i] = Bytes[currentIndex];
                currentIndex++;
            }
            
            ExceptionTableLength = (ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]);
            currentIndex += 2;
            for(int i = 0; i < ExceptionTableLength; i++)
            {
                ExceptionTable exceptionTable = new ExceptionTable((ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]), 
                    (ushort)(Bytes[currentIndex + 2] << 8 | Bytes[currentIndex + 3]), (ushort)(Bytes[currentIndex + 4] << 8 | Bytes[currentIndex + 5]),
                    (ushort)(Bytes[currentIndex + 6] << 8 | Bytes[currentIndex + 7]));
                currentIndex += 8;
                ExceptionTable[i] = exceptionTable;
            }

            CodeAttributeCount = (ushort)(Bytes[currentIndex] << 8 | Bytes[currentIndex + 1]);
            currentIndex += 2;
            
            Attributes = MethodInfo.MethodAttributes(Bytes, CodeAttributeCount, ref currentIndex, cpInfos);
        }
    }
}
