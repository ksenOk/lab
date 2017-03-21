using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    /// <summary>
    /// интерфейс Help
    /// </summary>
   
   
  interface Help
    {
  		/// <summary>
  		/// максимальное число UNITов которым можно помочь
  		/// </summary>
  		/// <returns>возвращают максимальное число UNITов которым можно помочь</returns>
        int Maxunit();
        /// <summary>
        /// метод определения максимальной помощи
        /// </summary>
        /// <returns>максимальное число единиц здоровья которые мы можем отдать</returns>
        int MaxHelp();
        /// <summary>
        /// метод  количество оказанной помощи
        /// </summary>
        /// <returns> возвращ. количесво UNITов которым уже помогли</returns>
        int Help();
        /// <summary>
        /// меняет значение количесво UNITов которым уже помогли на h
        /// </summary>
        /// <param name="h"> скольким Unitам помогли</param>
        void Help(int h);
      /// <summary>
      /// метод для лечащих типов войск
      /// </summary>
      /// <param name="person">кого нужно вылечить</param>
      /// <param name="powerH">на какое количество единиц здоровья</param>
        void HealingSombody(Unit person, int powerH);
    }
}
