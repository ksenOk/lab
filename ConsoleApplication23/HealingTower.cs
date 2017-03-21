using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
  /// <summary>
  /// подвид башни , которвая может оказывать помощь
  /// наследует все атрибуты и методы класса Unit 
  /// наследует интерфейс Help
  /// </summary>
    class HealingTower : Tower, Help
    {
        public int help;
        public int Maxunit() { return 3; }
        public int MaxHelp() { return 15; }
        public int Help() { return this.help; }
        public void Help(int h) { this.help = h; }
        public HealingTower(int i) : base((i > 20)? 20:i,0) {
            this.help = 0;
            this.LimitH = 20;
           
        }

        
   public void HealingSombody(Unit person, int powerH){
        if (this.help < this.MaxHelp())
            {
                               
                                person.Health= person.Health+powerH;
                                Console.WriteLine("Healing Tower give "+ powerH+" points of health ");
                                this.help+=1;
        }
        else{ Console.WriteLine("Healing Tower can not help somebody");}
        
    }

        }
}
