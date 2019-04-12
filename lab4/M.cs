using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class JaggedArr
    {
        public double[] child1;
        public double[] child2;
        public double[] parent = new double[2]{
            new double[],
            new double[]
        };
       
        public double this[int i,int j]
        {
            
            get
            {
                return ;
            }
            set
            {
                val[index] = value;
            }
        }

    }
}
