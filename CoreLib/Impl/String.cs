﻿namespace System
{
    using Runtime.CompilerServices;

    public partial class String
    {
        public static readonly String Empty = "";

        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return m_stringLength;
            }
        }

        [System.Runtime.CompilerServices.IndexerName("Chars")]
        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= m_stringLength)
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                unsafe
                {
                    fixed (char* p = this)
                    {
                        return *(p + index);
                    }
                }
            }
        }
    }
}