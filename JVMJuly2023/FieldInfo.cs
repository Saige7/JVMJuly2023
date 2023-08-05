using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023
{
    class FieldInfo
    {
        public enum Flags
        {
            AccPublic = 0x0001,     //Declared public; may be accessed from outside its package.
            AccPrivate = 0x0002,    //Declared private; usable only within the defining class.
            AccProtected = 0x0004,	//Declared protected; may be accessed within subclasses.
            AccStatic =	0x0008, 	//Declared static.
            AccFinal = 0x0010,	    //Declared final; never directly assigned to after object construction(JLS §17.5).
            AccVolatile = 0x0040,	//Declared volatile; cannot be cached.
            AccTransient = 0x0080,	//Declared transient; not written or read by a persistent object manager.
            AccSynthetic = 0x1000,	//Declared synthetic; not present in the source code.
            AccEnum = 0x4000	    //Declared as an element of an enum.
        }

        public Flags Flag { get; }
        public ushort NameIndex;
        public ushort DescriptorIndex;
        public ushort AttributesCount;
        public AttributeInfo[] Attributes;

        public FieldInfo(Flags flag, ushort nameIndex, ushort descriptorIndex, ushort attributesCount, AttributeInfo[] attributes)
        {
            Flag = flag;
            DescriptorIndex = descriptorIndex;
            AttributesCount = attributesCount;
            Attributes = attributes;
        }
    }
}
