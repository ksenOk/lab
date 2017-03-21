using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
	/// <summary>
	/// конный лучник
	/// подвид лучника
	/// </summary>
    class CavarlyArcher : Archer
    {
        public CavarlyArcher(int i, int p): base((i > 7) ? 7:i, (p > 10)? 10:p)
        {
            this.Iniciativ=2;
            this.LimitH = 7;
           
        }
    }
}
