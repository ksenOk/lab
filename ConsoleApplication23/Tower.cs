using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    /// <summary>
    /// подвид войск башни
	/// создать такую башню нельзя    
    /// </summary>
   abstract class Tower: Unit
    {
        public Tower(int i, int p): base(i, p, 1)
        {        
        }
    }

}
