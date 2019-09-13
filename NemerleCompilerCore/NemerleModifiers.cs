using System;

namespace Nemerle.Compiler
{
    [Flags]
    public enum NemerleModifiers
    {
        None            = 0x00000,
        Public          = 0x00001,
        Private         = 0x00002,
        New             = 0x00004,
        Protected       = 0x00008,
        Abstract        = 0x00010,
        Virtual         = 0x00020,
        Sealed          = 0x00040,
        Static          = 0x00080,
        Mutable         = 0x00100,
        Internal        = 0x00200,
        Override        = 0x00400,
        Struct          = 0x01000,
        Macro           = 0x02000,
        Volatile        = 0x04000,
        SpecialName     = 0x08000,
        Partial         = 0x10000,
        Extern          = 0x20000,

        CompilerMutable = 0x40000,

        VirtualityModifiers = New | Abstract | Virtual | Override,
        OverrideModifiers   = Abstract | Virtual | Override,
        AccessModifiers     = Public | Private | Protected | Internal,
    }
}