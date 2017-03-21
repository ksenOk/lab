using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
	/// <summary>
	/// лучник
	/// </summary>
    class Archer : Unit
    {
        public Archer(int i, int p) : base((i > 3) ?3 : i, (p > 3) ? 3 : p, 4)
            
        {
            this.LimitH = 3;


        }

    }
}
