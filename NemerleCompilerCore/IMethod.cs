using System;
using System.Collections.Generic;

namespace Nemerle.Compiler
{
    public interface IMethod : IMember
    {
        Tuple<FixedType, IList<TypeVar>> GetFreshType();
        TFunHeader Header { get; }
        TFunHeader GetHeader();
        System.Reflection.MethodBase GetMethodBase();
        System.Reflection.MethodInfo GetMethodInfo();
        System.Reflection.ConstructorInfo GetConstructorInfo();
        bool IsVarArgs  { get; }
        bool IsFinal  { get; }
        bool IsAbstract  { get; }
        bool IsExtension  { get; }
        BuiltinMethodKind BuiltinKind { get; }
        new FixedType.Fun GetMemType();

        /// Obtains list of parameters of typed method
        IList<TParameter> GetParameters();

        /// Obtain return type of typed method. If it is already inferred/fixed
        /// the value is one of FixedType variant options.
        TypeVar ReturnType  { get; }
        
    }
}