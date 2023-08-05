using JVMJuly2023.AttributeClasses;
using JVMJuly2023.CPInfoClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023
{
    class Program
    {
        static CPInfo[] ConstantPoolParse(byte[] Bytes, ref int currentIndex, ushort constantPoolCount)
        {
            CPInfo[] cpInfos = new CPInfo[constantPoolCount - 1];
            for (int i = 0; i < cpInfos.Length; i++)
            {
                switch (Bytes[currentIndex])
                {
                    case (byte)CPInfo.Tag.ConstantClass:
                        ushort nameIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        ConstantClassInfo classInfo = new ConstantClassInfo(nameIndex, Bytes[currentIndex]);
                        cpInfos[i] = classInfo;
                        currentIndex += 3;
                        break;
                    case (byte)CPInfo.Tag.ConstantFieldref:
                        ushort classIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        ushort nameAndTypeIndex = GetShort(Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantFieldrefInfo fieldrefInfo = new ConstantFieldrefInfo(classIndex, nameAndTypeIndex, Bytes[currentIndex]);
                        cpInfos[i] = fieldrefInfo;
                        currentIndex += 5;
                        break;
                    case (byte)CPInfo.Tag.ConstantMethodref:
                        classIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        nameAndTypeIndex = GetShort(Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantMethodrefInfo methodrefInfo = new ConstantMethodrefInfo(classIndex, nameAndTypeIndex, Bytes[currentIndex]);
                        cpInfos[i] = methodrefInfo;
                        currentIndex += 5;
                        break;
                    case (byte)CPInfo.Tag.ConstantInterfaceMethodref:
                        classIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        nameAndTypeIndex = GetShort(Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantInterfaceMethodrefInfo interfaceMethodrefInfo = new ConstantInterfaceMethodrefInfo(classIndex, nameAndTypeIndex, Bytes[currentIndex]);
                        cpInfos[i] = interfaceMethodrefInfo;
                        currentIndex += 5;
                        break;
                    case (byte)CPInfo.Tag.ConstantString:
                        ushort stringIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        ConstantStringInfo stringInfo = new ConstantStringInfo(stringIndex, Bytes[currentIndex]);
                        cpInfos[i] = stringInfo;
                        currentIndex += 3;
                        break;
                    case (byte)CPInfo.Tag.ConstantInteger:
                        uint bytes = GetUint(Bytes[currentIndex + 1], Bytes[currentIndex + 2], Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantIntegerInfo integerInfo = new ConstantIntegerInfo(bytes, Bytes[currentIndex]);
                        cpInfos[i] = integerInfo;
                        currentIndex += 5;
                        break;
                    case (byte)CPInfo.Tag.ConstantFloat:
                        bytes = GetUint(Bytes[currentIndex + 1], Bytes[currentIndex + 2], Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantFloatInfo floatInfo = new ConstantFloatInfo(bytes, Bytes[currentIndex]);
                        cpInfos[i] = floatInfo;
                        currentIndex += 5;
                        break;
                    case (byte)CPInfo.Tag.ConstantLong:
                        uint highBytes = GetUint(Bytes[currentIndex + 1], Bytes[currentIndex + 2], Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        uint lowBytes = GetUint(Bytes[currentIndex + 5], Bytes[currentIndex + 6], Bytes[currentIndex + 7], Bytes[currentIndex + 8]);
                        ConstantLongInfo longInfo = new ConstantLongInfo(highBytes, lowBytes, Bytes[currentIndex]);
                        cpInfos[i] = longInfo;
                        currentIndex += 9;
                        break;
                    case (byte)CPInfo.Tag.ConstantDouble:
                        highBytes = GetUint(Bytes[currentIndex + 1], Bytes[currentIndex + 2], Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        lowBytes = GetUint(Bytes[currentIndex + 5], Bytes[currentIndex + 6], Bytes[currentIndex + 7], Bytes[currentIndex + 8]);
                        ConstantDoubleInfo doubleInfo = new ConstantDoubleInfo(highBytes, lowBytes, Bytes[currentIndex]);
                        cpInfos[i] = doubleInfo;
                        currentIndex += 9;
                        break;
                    case (byte)CPInfo.Tag.ConstantNameAndType:
                        nameIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        ushort descriptorIndex = GetShort(Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantNameAndTypeInfo nameAndTypeInfo = new ConstantNameAndTypeInfo(nameIndex, descriptorIndex, Bytes[currentIndex]);
                        cpInfos[i] = nameAndTypeInfo;
                        currentIndex += 5;
                        break;
                    case (byte)CPInfo.Tag.ConstantUtf8:
                        ushort length = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        byte[] bytesArray = new byte[length];
                        for (int index = 0; index < bytesArray.Length; index++)
                        {
                            bytesArray[index] = Bytes[currentIndex + 3 + index];
                        }
                        ConstantUtf8Info utf8Info = new ConstantUtf8Info(length, bytesArray, Bytes[currentIndex]);
                        cpInfos[i] = utf8Info;
                        currentIndex += 3 + length;
                        break;
                    case (byte)CPInfo.Tag.ConstantMethodHandle:
                        byte referenceKind = Bytes[currentIndex + 1];
                        ushort referenceIndex = GetShort(Bytes[currentIndex + 2], Bytes[currentIndex + 3]);
                        ConstantMethodHandleInfo methodHandleInfo = new ConstantMethodHandleInfo(referenceKind, referenceIndex, Bytes[currentIndex]);
                        cpInfos[i] = methodHandleInfo;
                        currentIndex += 4;
                        break;
                    case (byte)CPInfo.Tag.ConstantMethodType:
                        descriptorIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        ConstantMethodTypeInfo methodTypeInfo = new ConstantMethodTypeInfo(descriptorIndex, Bytes[currentIndex]);
                        cpInfos[i] = methodTypeInfo;
                        currentIndex += 3;
                        break;
                    case (byte)CPInfo.Tag.ConstantInvokeDynamic:
                        ushort bootstrapMethodAttrIndex = GetShort(Bytes[currentIndex + 1], Bytes[currentIndex + 2]);
                        nameAndTypeIndex = GetShort(Bytes[currentIndex + 3], Bytes[currentIndex + 4]);
                        ConstantInvokeDynamicInfo invokeDynamicInfo = new ConstantInvokeDynamicInfo(bootstrapMethodAttrIndex, nameAndTypeIndex, Bytes[currentIndex]);
                        cpInfos[i] = invokeDynamicInfo;
                        currentIndex += 5;
                        break;
                }
            }
            return cpInfos;
        }
        static void CheckMagic(byte[] Bytes)
        {
            uint magic = 0x00000000;
            magic = (uint)(magic | (Bytes[0] << 24) | (Bytes[1] << 16) | (Bytes[2] << 8) | Bytes[3]);

            if (magic != 0xCAFEBABE)
            {
                throw new Exception("invaild file :(");
            }
            Console.WriteLine($"0x{magic:X0}");
        }
        static ushort GetShort(byte byte1, byte byte2)
        {
            ushort result = 0x0000;
            result = (ushort)(result | (byte1 << 8));
            result = (ushort)(result | byte2);

            return result;
        }
        static uint GetUint(byte byte1, byte byte2, byte byte3, byte byte4)
        {
            uint result = 0x0000;
            result = (uint)(result | (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4);

            return result;
        }
        static void Emulate(byte[] codeBytes)
        {
            Stack<uint> intStack = new Stack<uint>();
            uint[] localVariables = new uint[20];

            for(int i = 0; i < codeBytes.Length; i++)
            {
                byte opcode = codeBytes[i];
                switch (opcode)
                {
                    case 0x60:
                        uint num2 = intStack.Pop();
                        uint num1 = intStack.Pop();
                        intStack.Push(num1 + num2);
                        break;

                    case 0x10:
                        intStack.Push(codeBytes[i + 1]);
                        i++;
                        break;

                    case 0x3c:
                        uint value = intStack.Pop();
                        localVariables[1] = value;
                        break;
                    case 0x3d:
                        value = intStack.Pop();
                        localVariables[2] = value;
                        break;
                    case 0x3e:
                        value = intStack.Pop();
                        localVariables[3] = value;
                        break;

                    case 0x1b:
                        value = localVariables[1];
                        intStack.Push(value);
                        break;
                    case 0x1c:
                        value = localVariables[2];
                        intStack.Push(value);
                        break;
                }
            }


        }
        static void Main(string[] args)
        {
            byte[] Bytes = System.IO.File.ReadAllBytes(args[0]);

            CheckMagic(Bytes);
            int currentIndex = 4;

            ushort minorVerison = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            ushort majorVersion = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;

            ushort constantPoolCount = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;

            CPInfo[] cpInfos = ConstantPoolParse(Bytes, ref currentIndex, constantPoolCount);
            
            ushort accessFlags = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            ushort thisClass = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            ushort superClass = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;

            ushort interfacesCount = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            
            ushort[] interfaces = new ushort[interfacesCount];
            for(int i = 0; i < interfaces.Length; i++)
            {
                interfaces[i] = Bytes[currentIndex];
                currentIndex++;
            }

            ushort fieldsCount = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            FieldInfo[] fields = new FieldInfo[fieldsCount];
            currentIndex += fieldsCount;

            ushort methodsCount = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            MethodInfo[] methods = new MethodInfo[methodsCount];

            for (int i = 0; i < methodsCount; i++)
            {
                ushort accessFlag = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
                currentIndex += 2;
                ushort nameIndex = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
                currentIndex += 2;
                ushort descriptorIndex = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
                currentIndex += 2;
                ushort methodAttributesCount = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
                currentIndex += 2;

                AttributeInfo[] methodAttributes = MethodInfo.MethodAttributes(Bytes, methodAttributesCount, ref currentIndex, cpInfos);
                MethodInfo method = new MethodInfo(accessFlag, nameIndex, descriptorIndex, methodAttributes);
                methods[i] = method;
            }
       
            ushort attributesCount = GetShort(Bytes[currentIndex], Bytes[currentIndex + 1]);
            currentIndex += 2;
            AttributeInfo[] attributes = new AttributeInfo[attributesCount];
            for(int i = 0; i < attributesCount; i++)
            {
                attributes = MethodInfo.MethodAttributes(Bytes, attributesCount, ref currentIndex, cpInfos);
            }

            MethodInfo main = null;
            for(int i = 0; i < methods.Length; i++)
            {
                var bytes = ((ConstantUtf8Info)cpInfos[methods[i].NameIndex - 1]).Bytes;
                string value = Encoding.UTF8.GetString(bytes);

                var otherBytes = ((ConstantUtf8Info)cpInfos[methods[i].DescriptorIndex - 1]).Bytes;
                string otherValue = Encoding.UTF8.GetString(otherBytes);

                ushort flagToCheck = (ushort)(MethodInfo.Flags.AccPublic | MethodInfo.Flags.AccStatic);

                if (value == "main" && otherValue == "([Ljava/lang/String;)V" && methods[i].accessFlag == flagToCheck)
                {
                    main = methods[i];
                }
            }
            
            for(int i = 0; i < main.Attributes.Length; i++)
            {
                var bytes = ((ConstantUtf8Info)cpInfos[main.Attributes[i].AttributeNameIndex - 1]).Bytes;
                string value = Encoding.UTF8.GetString(bytes);
                if (value == "Code")
                {
                    byte[] codeBytes = ((Code)main.Attributes[i]).code;
                    Emulate(codeBytes);
                }
            }

        }
    }
}
