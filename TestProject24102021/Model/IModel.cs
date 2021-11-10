﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject24102021
{
    interface IModel
    {
        void Start();

        List<ISequence> GetSequences();

        List<SequenceInfo> GetSequencesInfo();
    }
}
