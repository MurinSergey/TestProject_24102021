using System;
using System.Collections.Generic;
using System.Threading;

namespace TestProject24102021
{
    class Program
    {
        //Константа количества потоков (последовательностей)
        public const int NUMBER_OF_SEQUENCE = 10;

        //Константа количества шагов в каждом потоке (последовательности)
        public const int NUMBER_OF_STEP = 100;

        //Константы для расчета случайного времени выполнения шага
        public const int MIN_DELAY_OF_STEP = 0;
        public const int MAX_DELAY_OF_STEP = 50;

       static void Main(string[] args)
        {
            IController _myController = new Controller(new Model(NUMBER_OF_SEQUENCE, NUMBER_OF_STEP));
            IView _myView = new ConsoleView(_myController);
            _myController.Start();
            new Thread(_myView.Start).Start();
        }
    }
}
