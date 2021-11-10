using System;
using System.Threading;

namespace TestProject24102021
{
    //Данный класс является элементарной единицей программы - ШАГ или ИТЕРАЦИЯ
    //Предпологается, что массив шагов будет создаваться в объектах ПОСЛЕДОВАТЕЛЬНОСТИ
    class EmptyStep : IStep
    {
        //Статус выполнения текущего шага
        // 0 - не выполнен
        // 1 - выполнен успешно
        //-1 - выполнен с ошибкой
        private int _status = 0;

        public int Status
        {
            get
            {
                return _status;
            }
        }

        public void Start()
        {
            doIt();
        }

        public int GetStatus()
        {
            return Status;
        }

        //Основной метод шага
        private void doIt()
        {
            //Усыпляем поток иммитирую деятельность
            Thread.Sleep(new Random().Next(Program.MIN_DELAY_OF_STEP, Program.MAX_DELAY_OF_STEP));

            //Рассчитываем шанс успеха
            int exceptionChance = new Random().Next(0, 10);

            //ЕСЛИ шаг выполняется успешно, то ставим в статус 1
            //ИНАЧЕ ставим статус -1
            try
            {
                if (exceptionChance > 8)
                {
                    throw new Exception();
                }
                _status = 1;
            }
            catch (Exception)
            {
                _status = -1;
            }
        }
    }
}
