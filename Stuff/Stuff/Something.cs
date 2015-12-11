using System;

namespace Stuff
{
    public class Something : ISomething
    {
        private readonly ISomethingElse m_SomethingElse;

        public Something(ISomethingElse somethingElse)
        {
            m_SomethingElse = somethingElse;
        }

        public void Do()
        {
            Console.WriteLine("Something");
            m_SomethingElse.DoSomethingElse();
        }
    }

    public class SomethingElse : ISomethingElse
    {
        public void DoSomethingElse()
        {
            Console.WriteLine("SomethingElse");
        }
    }

    public interface ISomething
    {
        void Do();
    }

    public interface ISomethingElse
    {
        void DoSomethingElse();
    }
}
