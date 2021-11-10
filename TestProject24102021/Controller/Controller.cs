using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestProject24102021
{
    class Controller : IController
    {
        private IModel _model;
        public Controller(IModel model)
        {
            _model = model;
        }

        //Метод запускает выполнение модели
        public void Start()
        {
            _model.Start();
        }

        //Метод передает данные из модели
        public List<SequenceInfo> GetViewData()
        {
            return _model.GetSequencesInfo();
        }
    }
}
