using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    /// <summary>
    /// абстрактный класс войнов - Unit
    /// </summary>
    abstract class Unit
    {

        /// <summary>
        /// параметр здоровье
        /// </summary>
        private int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        /// <summary>
        /// параметр сила
        /// </summary>
        private int power;
        public int Power
        {
            get { return power; }
            set { power = value; }
        }

        /// <summary>
        /// параметр инициатива
        /// </summary>
        private int iniciativ;
        public int Iniciativ
        {
            get { return iniciativ; }
            set { iniciativ = value; }
        }
        /// <summary>
        /// максимальное здоровье
        /// </summary>
        private int limitH;
        public int LimitH
        {
            get { return limitH; }
            set { limitH = value; }
        }

        public Unit()
        {
            this.health = 0;
            this.power = 0;
            this.iniciativ = 0;
        }

        public Unit(int h, int p, int i)
        {
            this.health = h;
            this.power = p;
            this.iniciativ = i;
        }





        /// <summary>
        /// метод позволяет получить данные о экземпляре
        /// </summary>
        /// <returns>возвращает строку с информацией</returns>

        public String toString()
        {
            String s = "Class " + this.GetType().Name + "\t Health: " + this.Health + " \tPower: " + this.Power + " \tIniciativ: " + this.Iniciativ;
            return s;

        }




    }
}
