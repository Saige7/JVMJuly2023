using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023
{
    public class CPInfo
    {
        public enum Tag : byte
        {
            ConstantClass = 7,
            ConstantFieldref = 9,
            ConstantMethodref = 10,
            ConstantInterfaceMethodref = 11,
            ConstantString = 8,
            ConstantInteger = 3,
            ConstantFloat = 4,
            ConstantLong = 5,
            ConstantDouble = 6,
            ConstantNameAndType = 12,
            ConstantUtf8 = 1,
            ConstantMethodHandle = 15,
            ConstantMethodType = 16,
            ConstantInvokeDynamic = 18
        }

        public Tag tag { get; }
        public Tag parsedTag { get;  }
        public CPInfo(Tag parsedTags, Tag tags)
        {
            parsedTag = parsedTags;
            tag = tags;
            if(parsedTag != tag)
            {
                throw new Exception("parse failed :(");
            }
        }
        


}
    
}
