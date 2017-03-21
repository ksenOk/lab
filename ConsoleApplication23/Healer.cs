using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
	/// <summary>
	/// лекарь
	/// наследует все атрибуты и методы класса Unit 
	/// наследует интерфейс Help
	/// </summary>
    class Healer: Unit, Help
    {

       public int help;
       public int Maxunit() { return 1; }
       public  int MaxHelp() { return 2; }
       public int Help() { return this.help; }
        public void Help(int h) { this.help = h; }

        public Healer(int i): base((i > 3)? 3 : i, 0,5){
            this.help=0;
            this.LimitH = 3;
    }



        public void HealingSombody(Unit person, int powerH)
                {
                        if (this.help < this.MaxHelp())
                         {
                      
                        person.Health = person.Health +powerH;
                        Console.WriteLine("Healer  give "+ powerH+" of health ");
                        this.help+=1;
                        }
                        else { Console.WriteLine("Healer can not help somebody"); }
        
                    }

        
    }
}
