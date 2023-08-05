using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023
{
    class ClassFile
    {
        public enum accessFlags : ushort
        {
            AccPublic = 0x0001,	        //Declared public; may be accessed from outside its package.
            AccFinal = 0x0010,	        //Declared final; no subclasses allowed.
            AccSuper = 0x0020,	        //Treat superclass methods specially when invoked by the invokespecial instruction.
            AccInterface = 0x0200,	    //Is an interface, not a class.
            AccAbstract = 0x0400,	    //Declared abstract; must not be instantiated.
            AccSynthetic = 0x1000,	    //Declared synthetic; not present in the source code.
            AccAnnotation = 0x2000,	    //Declared as an annotation type.
            AccEnum = 0x4000	        //Declared as an enum type. 
        }


        public byte Magic;
        public ushort MinorVersion;
        public ushort MajorVersion;
        public ushort ConstantPoolCount;
        public CPInfo[] ConstantPool;
        public ushort AccessFlags;      //**
        public ushort ThisClass;
        public ushort SuperClass;
        public ushort InterfaceCount;
        public ushort[] Interfaces;
        public ushort FieldsCount; 
        public FieldInfo[] Fields;
        public ushort MethodsCount;
        public MethodInfo[] Methods;
        public ushort AttributeCount;
        public AttributeInfo[] Attributes;

        public ClassFile(byte magic, ushort minorVersion, ushort majorVerison, ushort constantPoolCount, CPInfo[] constantPool, ushort accessFlags, ushort thisClass,
            ushort superClass, ushort interfaceCount, ushort[] interfaces, ushort fieldsCount, FieldInfo[] fields, ushort methodsCount, MethodInfo[] methods,
            ushort attributeCount, AttributeInfo[] attributes)
        {
            Magic = magic;
            MinorVersion = minorVersion;
            MajorVersion = majorVerison;
            ConstantPoolCount = constantPoolCount;
            ConstantPool = constantPool;
            AccessFlags = accessFlags;  //**
            ThisClass = thisClass;
            SuperClass = superClass;
            InterfaceCount = interfaceCount;
            Interfaces = interfaces;
            FieldsCount = fieldsCount;
            Fields = fields;
            MethodsCount = methodsCount;
            Methods = methods;
            AttributeCount = attributeCount;
            Attributes = attributes;
        }
    }
}
