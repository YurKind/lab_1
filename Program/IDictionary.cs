using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Program
{
    class IDictionary<T1, T2>
    {
        public List<T1> Keys = new List<T1>();
        public List<T2> Values = new List<T2>();

        public void Add(T1 t1, T2 t2)
        {
            Keys.Add(t1);
            Values.Add(t2);
        }

        public void Clear()
        {
            Keys.Clear();
            Values.Clear();
        }

        public int Count()
        {
            return Keys.Count;
        }
    }
}
