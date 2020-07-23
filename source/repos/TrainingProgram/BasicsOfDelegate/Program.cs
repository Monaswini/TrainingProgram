using System;

namespace BasicsOfDelegate
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //WorkPerformedHandler del1 = new WorkPerformedHandler(WorkPerformed1);
            //WorkPerformedHandler del2 = new WorkPerformedHandler(WorkPerformed2);

            //del1 += del2;
            //Console.WriteLine(del1(2, WorkType.GotoMeeting));

        }

        static int WorkPerformed1(int hours, WorkType worktype)
        {
            Console.WriteLine("WorkPerformed1");
            return hours + 1;
        }

        static int WorkPerformed2(int hours, WorkType worktype)
        {
            Console.WriteLine("WorkPerformed2");
            return hours + 2;
        }
    }
    public enum WorkType
    {
        GotoMeeting,
        ReportTheDocument,
        Golf
    }
}
