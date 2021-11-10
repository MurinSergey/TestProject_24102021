using System;
using System.Collections.Generic;

namespace TestProject24102021
{
    class ConsoleView : IView
    {
        private IController _controller;

        public ConsoleView(IController controller)
        {
            _controller = controller;
        }

        public void Start()
        {
            Console.CursorVisible = false;
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            ConsoleColor color = Console.ForegroundColor;
            bool allDone = false;
            while (!allDone)
            {
                allDone = true;
                List<SequenceInfo> sequenceInfos = _controller.GetViewData();
                for (int i = 0; i < sequenceInfos.Count; i++)
                {
                    Console.ForegroundColor = color;
                    Console.Write("{0}( {1} ) ", i.ToString("00"), sequenceInfos[i].ThreadID.ToString("00"));
                    int[] steps = sequenceInfos[i].StepsStatus;
                    for (int x = 0; x < steps.Length; x++)
                    {
                        if (steps[x] == 0)
                        {
                            break;                     
                        }
                        else if (steps[x] < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.Write('▌');
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" {0}", sequenceInfos[i].Progress.ToString("00"));
                    
                    if (sequenceInfos[i].IsDone)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  {0}! ({1})", sequenceInfos[i].DoneNumber.ToString("00") ,sequenceInfos[i].DoneTime);
                    }
                    Console.WriteLine();
                    allDone = allDone && sequenceInfos[i].IsDone;
                }
                if (allDone)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("All Done!");
                    Console.WriteLine();
                    Console.CursorVisible = true;
                    Console.ForegroundColor = color;
                    Console.ReadLine();
                }
                else
                {
                    Console.CursorLeft = left;
                    Console.CursorTop = top;
                }
            }
        }
    }
}
