using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject24102021
{
    interface IController
    {
        void Start();

        List<SequenceInfo> GetViewData();
    }
}
