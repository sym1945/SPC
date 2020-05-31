using System;

namespace SPC.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SpcDeviceAttribute : Attribute
    {
        public int Offset { get; private set; }

        public int Length { get; private set; }

        public string Desc { get; set; }


        public SpcDeviceAttribute(int offset)
        {
            Offset = offset;
        }
        public SpcDeviceAttribute(int offset, int length) : this(offset)
        {
            Length = length;
        }

    }
}