using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
	/// <summary>
	/// подвид башни - атакующая башня
	/// </summary>
    class AttackingTower: Tower
    {
        public AttackingTower(int i, int p): base((i > 30)? 30:i, (p > 20)? 20:i){

            this.LimitH = 30;
        }
  
    }
}
