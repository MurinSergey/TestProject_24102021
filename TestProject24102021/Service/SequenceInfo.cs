using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject24102021
{
    //Класс для сбора информации о текущих последовательностях
    class SequenceInfo
    {

        //ID потока в котором выполняется последовательность
        private int _threadID;

        public int ThreadID
        {
            get
            {
                return _threadID;
            }
        }

        //Информация о прогрессе выполнения последовательности
        private int _progress;

        public int Progress
        {
            get
            {
                return _progress;
            }
        }

        //Информация о состоянии шагов
        private int[] _stepsStatus;

        public int[] StepsStatus
        {
            get
            {
                return _stepsStatus;
            }
        }

        //Инофрмация о завершении последовательности
        private bool _isDone;

        public bool IsDone
        {
            get
            {
                return _isDone;
            }
        }

        //Количество времени затраченное на выполение последовательности
        private float _doneTime;

        public float DoneTime
        {
            get
            {
                return _doneTime;
            }
        }

        //Номер с которым последовательность завершилась
        private int _doneNumber;

        public int DoneNumber
        {
            get
            {
                return _doneNumber;
            }
        }

        public SequenceInfo(int threadID, int progress, int[] stepsStatus, bool isDone, float doneTime, int doneNumber)
        {
            _threadID = threadID;
            _progress = progress;
            _stepsStatus = stepsStatus;
            _isDone = isDone;
            _doneTime = doneTime;
            _doneNumber = doneNumber;
        }
    }
}
