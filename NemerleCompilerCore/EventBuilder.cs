using System.Reflection;

namespace Nemerle.Compiler
{
    public class EventBuilder : MemberBuilder, IEvent
    {
        public EventInfo GetEventInfo()
        {
            throw new System.NotImplementedException();
        }

        public IMethod GetAdder()
        {
            throw new System.NotImplementedException();
        }

        public IMethod GetRemover()
        {
            throw new System.NotImplementedException();
        }
    }
}