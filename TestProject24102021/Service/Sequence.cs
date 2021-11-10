using System;
using System.Collections.Generic;
using System.Threading;

namespace TestProject24102021
{
    class Sequence : ISequence
    {
        //Общая переменная для всех последовательностей
        static int CountDoneSequences = 0;
        static object locker = new object();

        //Инкрементирует счетчик завершенных последовательностей
        static int IncrementDoneSequences()
        {
            lock(locker)
            {
                CountDoneSequences++;
                return CountDoneSequences;
            }    
        }
        //Сбрасывает счетчик завершенных последовательностей
        public static void ResetCounterDoneSequences()
        {
            lock(locker)
            {
                CountDoneSequences = 0;
            }
        }

        //Ссылка на поток в котором запущена последовательность
        private int _threadID;

        //Список всех ШАГОВ текущей последовательности
        private List<IStep> _steps = new();

        //Количество выполненных шагов
        private int _passedStep = 0;

        //Время запуска последовательности
        private DateTime _startTime;

        //Время затраченное на выполнение последовательности
        private float _doneTime = 0f;

        //Порядковый номер с которым завершилась последовательность
        private int _doneNumber = 0;

        //В конструкторе принимаем количество ШАГОВ для этой последовательности
        //и заполняет лист ШАГОВ
        public Sequence (int numberOfSteps)
        {
            for (int i = 0; i < numberOfSteps; i++)
            {
                _steps.Add(new EmptyStep());
            }
        }

        //Запуск последовательности через интерфейс
        public void Start()
        {
            doIt();
        }

        //Возвращает ID потока в котором запущена последовательность
        public int GetThreadID()
        {
            return _threadID;
        }

        //Возвращает массив содержащий статусы всех шагов
        public int[] GetStatusSteps()
        {
            int[] result = new int[_steps.Count];
            for (int i = 0; i < _steps.Count; i++)
            {
                result[i] = _steps[i].GetStatus();
            }
            return result;
        }

        //Возвращает прогресс последовательности
        public int GetProgress()
        {
            return _passedStep;
        }

        //Возвращает время затраченное на выполнение последовательности
        public float GetDoneTime()
        {
            return _doneTime;
        }

        //Возвращает true, если все шаги пройдены
        public bool IsFinished()
        {
            return _passedStep == _steps.Count;
        }
        //Возращает номер с которым завершилась последовательность
        public int GetDoneNumber()
        {
            return _doneNumber;
        }

        //Основной метод последовательности, который последовательно запускает ШАГИ
        private void doIt()
        {
            //Сбрасываем прогресс
            _passedStep = 0;
            //Сбрасываем время выполнения
            _doneTime = 0f;
            //Запоминаем время запуска
            _startTime = DateTime.Now;
            //Запоминаем поток в котором запущена последовательность
            _threadID = Thread.CurrentThread.ManagedThreadId;

            for (int i = 0; i < _steps.Count; i++)
            {
                _steps[i].Start();
                _passedStep = i + 1;
                TimeSpan timeSpan = DateTime.Now - _startTime;
                _doneTime = (float)timeSpan.TotalSeconds + ((float)timeSpan.TotalMilliseconds / (float)1000);
            }
            _doneNumber = IncrementDoneSequences();
        }
    }
}
