using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestProject24102021
{
    class Model : IModel
    {
        //Лист все доступных последовательностей
        private List<ISequence> _list = new();
        public Model(int numberSequence, int numberStep)
        {
               for (int i = 0; i < numberSequence; i++)
            {
                _list.Add(new Sequence(numberStep));
            }
        }

        //Возвращает список всех доступных последовательностей
        public List<ISequence> GetSequences()
        {
            return _list;
        }

        //Запускает выполнение всех последовательностей в отдельных потоках 
        public void Start()
        {
            Sequence.ResetCounterDoneSequences();
            for (int x = 0; x < _list.Count; x++)
            {
                new Thread(_list[x].Start).Start();
            }
        }

        //Возвращае список объектов, которые описывают текущее стостояние последовательностей
        public List<SequenceInfo> GetSequencesInfo()
        {          
            List<SequenceInfo> result = new();
            for (int i = 0; i < _list.Count; i++)
            {
                int threadID = _list[i].GetThreadID();
                int progress = _list[i].GetProgress();
                float doneTime = _list[i].GetDoneTime();
                int[] stepsStatus = _list[i].GetStatusSteps();
                bool isDone = _list[i].IsFinished();
                int doneNumber = _list[i].GetDoneNumber();
                result.Add(new SequenceInfo(threadID, progress, stepsStatus, isDone, doneTime, doneNumber));
            }
            return result;
        }
    }
}
