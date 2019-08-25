using System;

namespace Nemerle.Core
{
	/// <summary>
	///   <para>This namespace is always opened</para>
	/// </summary>
	[Serializable]
	public class AssertionException : Exception
	{
		public AssertionException()
		{
		}

		public AssertionException(string file, int line, string cond, string msg)
            : base(CreateMessage(file, line, cond, msg))
        {
        }

        private static string CreateMessage(string file, int line, string cond, string msg)
        {
            string text = (!(cond != "")) ? "" : (" ``" + cond + "''");
            text = "assertion" + text + " failed in file " + file + ", line " + line.ToString();
            text = ((!(msg != "")) ? text : (text + ": " + msg));
            return text;
        }
    }

    [Serializable]
    public class MatchFailureException : Exception
    {
    }
}
