using System;
using System.Collections.Generic;
using System.Text;

namespace DoExercise
{
    public abstract class AGrade
    {
        protected StringBuilder _outSeq = new StringBuilder();
        protected Dictionary<string, Func<string>> _dicFunctions = new Dictionary<string, Func<string>>();

        public abstract AGrade Init();
        public abstract void ExcuteToOut();
    }
}
