using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023.AttributeClassesHelpers
{
    public class lineNumberTable
    {
        public ushort StartPC;
        public ushort LineNumber;
        
        public lineNumberTable(ushort startPC, ushort lineNumber)
        {
            StartPC = startPC;
            LineNumber = lineNumber;
        }
    }
}
