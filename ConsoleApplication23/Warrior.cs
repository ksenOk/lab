using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    /// <summary>
    /// воин
    /// </summary>
    class Warrior: Unit
    {
        public Warrior(int i, int p): base((i > 5) ? 5:i, (p > 2)? 2:p , 6) {
            this.LimitH = 5;
            
  
        }
    }
}
