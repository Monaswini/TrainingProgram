using System;
using System.Collections.Generic;
using System.Text;

namespace BasicsOfDelegate
{
    public delegate int WorkPerformedHandler(int hours, WorkType worktype);

    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event EventHandler WorkCompleted;

        public void DoWork(int hours, WorkType workType)
        {

        }
    }
}
