using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication23
{
    class Program
    {
        static Random rdn = new Random();

        static void Main(string[] args)
        {

            List<Unit> list1 = new List<Unit>();
            List<Unit> list2 = new List<Unit>();
			
            //kolvo - определяет количество войнов в каждой армии
            // предполагается , что это значение можно менять 
            int kolvo = 10;
            CreateArmy(ref list1, kolvo);
            CreateArmy(ref list2, kolvo);


            Console.WriteLine("До боя состав армии:");
            Console.WriteLine("Army 1");
            foreach (Unit elem in list1)
            {
                Console.WriteLine(elem.toString());
            }
            Console.WriteLine("Army 2");
            foreach (Unit elem in list2)
            {
                Console.WriteLine(elem.toString());
            }
           
            Console.WriteLine("Ожиаем нажатие  кнопки Enter для продолжения......");
            Console.ReadLine();

            list1 = list1.OrderBy(x => x.Iniciativ).ToList();
            list2 = list2.OrderBy(x => x.Iniciativ).ToList();



            using (System.IO.StreamWriter file = new System.IO.StreamWriter("log.txt"))
            {
                Console.WriteLine("До боя отсортированный по инициативам состав армии:");
                file.WriteLine("До боя состав армии:");
                file.WriteLine("Army 1");
                Console.WriteLine("Army 1");
                OutArmy(ref list1, file);
                file.WriteLine("Army 2");
                Console.WriteLine("Army 2");
                OutArmy(ref list2, file);
                Console.WriteLine("Ожиаем нажатие  кнопки Enter для продолжения......");
                Console.ReadLine();

                Fight12(ref list1, ref list2, file);
            }
            Console.ReadLine();
            Console.ReadLine();
        }


        
        
        /// <summary>
        ///  метод сравнивающий инициативы
        /// </summary>
        /// <param name="a"> воин из одной армии</param>
        /// <param name="b"> воин из другой армии</param>
        /// <returns> возвращается номер 1 или 2 , в зависимости от того, какой воин будет ходить</returns>
        public static int wariorByCriteria(Unit a, Unit b)
        {

            if (a.Iniciativ < b.Iniciativ) { return 1; }

            else if (a.Iniciativ == b.Iniciativ)
            {
                Random r = new Random();
                double c = r.NextDouble();

                if (c >=0.5) { return 1; } else { return 2; }
            }
            else { return 2; }

        }

      
     
         
        /// <summary>
        /// метод определяющиу действия игрока в зависимости от вида (лечащий или атакующий)
        /// </summary>
        /// <param name="list1"> армия против которой ходят</param>
        /// <param name="list2"> армия из которой ходит игрок</param>
        /// <param name="file"> выходной поток (файл, в который будет производиться запись)</param>
        /// <param name="l1"> указатели для армии, против которой ходят</param>
        /// <param name="l2"> указатель для армии, из которой игрок ходит</param>
        
        public static void fight1(ref List<Unit> list1, ref List<Unit> list2, System.IO.StreamWriter file, ref int l1, ref int l2)
        {



            if (list2[l2] is Help)
            {

              
                int c = rdn.Next(0, (list2.FindAll(x => x.Health < x.LimitH)).Count);

                int i = 0; int sum = 0;
                while ((i < list2.Count) && (sum < ((Help)list2[l2]).MaxHelp()) && (((Help)list2[l2]).MaxHelp() < ((Help)list2[l2]).Maxunit()))
                {
                    int l;
                    if (i != ((Help)list2[l2]).Maxunit() - 1)
                    {
                        l = rdn.Next(1, ((Help)list2[l2]).MaxHelp() - sum);
                    }
                    else
                    { l = ((Help)list2[l2]).MaxHelp() - sum; }


                  
                    if (list2.Count != 0 && (!(list2[c] is Help)))
                    {
                        ((Help)list2[l2]).HealingSombody(list2[c], l);
                        sum += l;

                        Console.WriteLine("Вылечил : " + list2[c].toString());
                        file.WriteLine("Вылечил : " + list2[c].toString());
                    }
                    else { break; }
                    ++i;
                    c = rdn.Next(0, list2.Count);
                }



                ((Help)list2[l2]).Help(0);
            }
            else
            {
                int c = rdn.Next(0, list1.Count);
                int p = list1[c].Health - list2[l2].Power;
                list1[c].Health = p;
                Console.WriteLine("Ходит против : " + list1[c].toString());
                file.WriteLine("Ходит против : " + list1[c].toString());
                if (list1[c].Health <= 0)
                {
                    list1.RemoveAt(c);

                   
                    if (l1 == list1.Count) l1 = 0;
                }
            }
        }

        
        /// <summary>
        /// метод реализующий алгоритм боя
        /// </summary>
        /// <param name="list1"> армия 1</param>
        /// <param name="list2"> армия 2</param>
        /// <param name="file">выходной поток (файл, в который будет производиться запись)</param>
        public static void Fight12(ref List<Unit> list1, ref List<Unit> list2, System.IO.StreamWriter file)
        {
            int l1 = 0;
            int l2 = 0;
            int q = 0;
            while (list1.Count * list2.Count != 0)
            {
                
                if (wariorByCriteria(list1[l1], list2[l2]) == 1)
                {

                    Console.WriteLine("Первым ходит игрок из армии 1:");
                    Console.WriteLine(list1[l1].toString());

                    file.WriteLine("Первым ходит игрок из армии 1:");
                    file.WriteLine(list1[l1].toString());

                    fight1(ref list2, ref list1, file, ref l2, ref l1);
                    l1++;

                }
                else
                {

                    Console.WriteLine("Первым ходит игрок из армии 2:");
                    Console.WriteLine(list2[l2].toString());
                    file.WriteLine("Первым ходит игрок из армии 2:");
                    file.WriteLine(list2[l2].toString());
                    fight1(ref list1, ref list2, file, ref l1, ref l2);
                    l2++;

                }

               
                if (l1 == list1.Count) l1 = 0;
                if (l2 == list2.Count) l2 = 0;
                if (list1.All(x => x is Help) && list2.All(x => x is Help)) { break; }
                if (list1.All(x => x is Help)||list2.All(x => x is Help)) { q++; }  if (q>100) { break; }
            }

            if (list2.Count == 0)
            {
                Console.WriteLine("Army 1");
                file.WriteLine("Army 1");
                OutArmy(ref list1, file);
                Console.WriteLine("Army 1 WIN");
                file.WriteLine("Army 1 WIN");
            }
            else if (list1.Count == 0)
            {
                Console.WriteLine("Army 2");
                file.WriteLine("Army 2");
                OutArmy(ref list2, file);
                Console.WriteLine("Army 2 WIN");
                file.WriteLine("Army 2 WIN");
                Console.ReadLine();
            }
            else { Console.WriteLine("DRAW");
            Console.WriteLine("Army 1");
            file.WriteLine("Army 1");
            OutArmy(ref list1, file);
           
            Console.WriteLine("Army 2");
            file.WriteLine("Army 2");
            
            OutArmy(ref list2, file);
            Console.WriteLine("DRAW");
            Console.ReadLine();
            }

        }

       
        /// <summary>
        /// метод создания армий 
        /// </summary>
        /// <param name="list">list, куда записывается армия</param>
        /// <param name="kolvo">количество бойцов в армии</param>
        public static void CreateArmy(ref List<Unit> list, int kolvo)
        {
            for (int i = 0; i < kolvo; i++)
            {
                Unit player;
                switch (rdn.Next(1, 8))
                {

                    case 1: player = new Archer(rdn.Next(1, 3), rdn.Next(1, 3)); break;
                    case 2: player = new Cavalery(rdn.Next(1, 10), rdn.Next(1, 7)); break;
                    case 3: player = new CavarlyArcher(rdn.Next(1, 7), rdn.Next(1, 10)); break;
                    case 4: player = new Healer(rdn.Next(1, 3)); break;
                    case 5: player = new Warrior(rdn.Next(1, 5), rdn.Next(1, 2)); break;
                    case 6: player = new AttackingTower(rdn.Next(1, 30), rdn.Next(1, 20)); break;
                    default: player = new HealingTower(rdn.Next(1, 20)); break;
                }
                list.Add(player);

            }


        }
        
        
        /// <summary>
        /// метод позволяет записать армию в файл и консоль
        /// </summary>
        /// <param name="list"> армия </param>
        /// <param name="file"> выходной поток (файл)</param>
        public static void OutArmy(ref List<Unit> list, System.IO.StreamWriter file)
        {

            foreach (Unit elem in list)
            {

                Console.WriteLine(elem.toString());
                file.WriteLine(elem.toString());
            }
        }



    }
}
