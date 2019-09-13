namespace Nemerle.Compiler
{
    public interface IEvent : IMember
    {
        System.Reflection.EventInfo GetEventInfo();
        IMethod GetAdder();
        IMethod GetRemover();
    }
}