using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    class Cavalery : Warrior
    {
        public Cavalery(int i, int p) : base((i > 10)? 10:i, (p > 7)?7:p)
        {

          
            this.Iniciativ=3;
            this.LimitH = 10;
           

        }
    }
}
