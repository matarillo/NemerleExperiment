﻿namespace Nemerle.Compiler
{
    public abstract class MemberInfo
    {
/*
  public StartTyping() : void
  {
    _userData = null;
  }
  
  mutable _userData : SC.IDictionary;

  public UserData : SC.IDictionary
  {
    get
    {
      when (_userData == null)
        _userData = SCS.ListDictionary();

      _userData
    }
  }

  public virtual IsConstructor : bool { get { false } }

  [Accessor]
  protected mutable is_obsolete : bool;
  [Accessor]
  protected mutable attributes : NemerleModifiers;

  public virtual IsStatic : bool
  {
    get { attributes %&& NemerleModifiers.Static }
  }

  public IsPublic : bool
  {
    get { attributes %&& NemerleModifiers.Public }
  }

  public IsPrivate : bool
  {
    get { attributes %&& NemerleModifiers.Private }
  }

  public IsProtected : bool
  {
    get { attributes %&& NemerleModifiers.Protected }
  }

  public IsInternal : bool
  {
    get { attributes %&& NemerleModifiers.Internal }
  }

  public IsAbstract : bool { get { attributes %&& NemerleModifiers.Abstract } }

  public virtual HasBeenUsed : bool // for the 'unused' warnings
  {
    get { true; } // default impl
    set
    {
      when (is_obsolete && value) // value indicates if we should warn about obsolete
      {
        mutable msg, is_error;
        (msg, is_error) = GetObsoletionDetails ();

        if (msg == null)
          msg = $"$this is obsolete";
        else
          msg = $"$this is obsolete: '$msg'";

        if (is_error)
          Message.Error (msg);
        else
          Message.Warning (618, msg);
      }
    }
  }

  public abstract GetModifiers () : AttributesAndModifiers;
  public abstract IsCustomAttributeDefined(attributeFullName : string) : bool;
  public abstract GlobalEnv : GlobalEnv { get; }

  internal virtual GetObsoletionDetails () : string * bool
  {
    def obsoletion_tc = this.GlobalEnv.Manager.InternalType.Obsolete_tc;
    def mods = GetModifiers ();
    assert(mods != null, this.ToString ());
    def (_, parms) = mods.FindAttributeWithArgs (obsoletion_tc, this.GlobalEnv).Value;
    mutable msg = null, is_error = false;
    foreach (x in parms) {
      | <[ $(m : string) ]> => msg = m;
      | <[ $(b : bool) ]> => is_error = b;
      | <[ Message = $(m : string) ]> => msg = m;
      | <[ IsError = $(b : bool) ]> => is_error = b;
      | _ => ()
    }
    (msg, is_error)
  }

  public CanAccess(memberTypeInfo : TypeInfo, currentTypeInfo : TypeInfo, isThisAccess : bool) : bool
  {
    def isCurrentOrNested(memberTypeInfo, currentTypeInfo)
    {
      if (currentTypeInfo == null || memberTypeInfo == null)
        false
      else if (memberTypeInfo.Equals(currentTypeInfo))
        true
      else
        isCurrentOrNested(memberTypeInfo, currentTypeInfo.DeclaringType)
    }

    if (IsPublic)
      true
    else if (IsInternal && 
    		(memberTypeInfo is TypeBuilder ||
    		memberTypeInfo.CanAccess(currentTypeInfo)))
      true
    else if (isCurrentOrNested(memberTypeInfo, currentTypeInfo))
      true
    else if (IsProtected)
    {
      if (isThisAccess)
        // Проверяем является ли текущий тип наследником типа в котором объявлен член к которому осуществляется доступ.
        currentTypeInfo.IsDerivedFrom(memberTypeInfo)
      else
        // Проверяем является текущий тип родительским для типа члена.
        memberTypeInfo.IsDerivedFrom(currentTypeInfo)
    }
    else
      false
  }

  public virtual IsConditional : bool { get { false } }

  public virtual GetConditions() : list[string] { [] }

 */
    }
}