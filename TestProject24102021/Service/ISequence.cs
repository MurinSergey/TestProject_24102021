using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestProject24102021
{
    interface ISequence
    {
        void Start();
        int GetThreadID();
        int[] GetStatusSteps();
        int GetProgress();
        float GetDoneTime();
        bool IsFinished();
        int GetDoneNumber();
    }
}
