using System;
using System.Collections.Generic;
using System.Text;

namespace JVMJuly2023
{
    public class ExceptionTable
    {
        public ushort StartPC;
        public ushort EndPC;
        public ushort HandlerPC;
        public ushort CatchType;

        public ExceptionTable(ushort startPC, ushort endPC, ushort handlerPC, ushort catchType)
        {
            StartPC = startPC;
            EndPC = endPC;
            HandlerPC = handlerPC;
            CatchType = catchType;
        }
    }
}
