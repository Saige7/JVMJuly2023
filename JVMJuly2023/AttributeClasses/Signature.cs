using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClasses
{
    class Signature : AttributeInfo
    {
        ushort SignatureIndex;
        public Signature(ushort attributeNameIndex, uint attributeLength, ushort signatureIndex) : base(attributeNameIndex, attributeLength)
        {
            SignatureIndex = signatureIndex;
        }
    }
}
