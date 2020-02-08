using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class Owner : IWritableObject, IReadableObject
    {
        private string FIO;
        private string phone;
        private static string a1 = "Owner.txt";
        public Owner(string FIO, string phone, ref List<Owner> owner)
        {
            this.FIO = FIO;
            this.phone = phone;
            WriteLine(a1, ref owner);
            //this.Agency = agency;
          
        }

        public Owner(ILoadManager man)
        {
            FIO = man.ReadLine().Split(':')[1];
            phone = man.ReadLine().Split(':')[1];
          
        }
        /*public Owner(string FIO, string phone,string agency, ref List<Owner> owner,ref List<Object1> obj) 
        {
            int i = 0;
            
            foreach (Owner p in owner)
            {
                
                if (FIO == p.FIO && phone == p.phone)
                {
                    i++;
                    Console.WriteLine("Такой владелец уже зарегестрирован, хотите посмотреть его данные? 1-да, 2-нет");
                    int c = Convert.ToInt32(Console.ReadLine());
                    if (c == 1) { Console.WriteLine(p.FIO + "  "+ p.phone); }
                    else { break; }
                    break;
                }
                
                /*if (this != p.getFIO())
                {
                    Console.WriteLine("Ввдите номер владельца:");
                    owner.Add(new Owner(Owner, Console.ReadLine()));
                }
            }
            if (i==0)
            {
                owner.Add(new Owner(FIO, phone,agency));
                
            }
        }*/


        public void InputFioPhone()
        {
            Console.WriteLine("Введите фио владельца объекта");
            FIO = Console.ReadLine();
            Console.WriteLine("Введите фио контактный телефон владельца");
            phone = Console.ReadLine();
        }
        /* public static void OpenFile1(string a) {
             FileStream file = new FileStream(a, FileMode.Open); //открывает файл только на чтение
             StreamReader reader = new StreamReader(file); // создаем «потоковый читатель» и связываем его с файловым потоком 
             StreamReader reader2 = new StreamReader(file);

             Console.WriteLine(reader.ReadToEnd());
             if (reader.ReadToEnd() == "")
             {
                 Console.WriteLine("Пусто");

             }
             else Console.WriteLine(reader2.ReadToEnd());
             reader.Close();
             reader2.Close();
         }*/

        public static void InputOwner(ref List<Owner> owner)
        {
            do
            {

                Console.WriteLine("Просмотреть список владельцев - 1, добавить нового - 2, удалить-3, Закончить - 4");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    Files.OpenFile1(a1);
                    /* Console.WriteLine("Хотите подробную информацию? 1-да, 2-нет");
                     int a3 = Convert.ToInt32(Console.ReadLine());
                      if (a3 == 1)
                      {
                          Console.WriteLine("Введите ФИО");
                          string dop1 = Console.ReadLine();
                          //Object1.dop(ref owner,ref object1,dop1); }
                      }*/
                   // view(ref owner);
                }
                if (a == 2)
                {
                    Console.WriteLine("Введите ФИО");
                    string a2 = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона");
                    string a1 = Console.ReadLine();
                    /* Console.WriteLine("Введите наименование агенства");
                     string a4 = Console.ReadLine();
                     Console.WriteLine("Введите номер агенства");
                     string a5 = Console.ReadLine();
                     Console.WriteLine("Введите адресс агенства");
                     string a6 = Console.ReadLine();
                     agency.Add(new Agency(a4, a5, a6));*/
                    owner.Add(new Owner(a2, a1, ref owner));
                    InputDop(ref owner);
                    Console.WriteLine("Готово");
                }
                if (a == 3)
                {
                    FileStream file1 = new FileStream(a1, FileMode.Create);
                    file1.Close();
                    //Files.DeleteFil(ref owner, a1);
                    /*Console.WriteLine("Введите ФИО владельца, которого вы хотите удалить");
                    string DeleteOwner = Console.ReadLine();
                    FileStream file1 = new FileStream("C:\\Users\\79889\\source\\repos\\ConsoleApp3\\Files\\Owner.txt", FileMode.Create); //создаем файловый поток
                    StreamWriter writer = new StreamWriter(file1); //создаем «потоковый писатель» и связываем его с файловым потоком 
                    foreach (Owner p in owner)
                    {
                        if (p.FIO == DeleteOwner)
                        {
                            owner.Remove(p);
                            break;
                        }
                        //else { Console.WriteLine("Нет такого человека"); }  
                    }
                    foreach (Owner p in owner)
                    {
                        writer.Write("\n" + p.FIO + "\n" + p.phone + "\n---------------"); //записываем в файл
                    }
                    writer.Close();*/
                }
                if (a == 4) break;

            } while (true);
        }

        public string getFIO()
        {
            return FIO;
        }
        public string getPhone()
        {
            return phone;
        }

        public string getA()
        {
            return a1;
        }

        /*public static void dop( ref List<Owner> owner, string dop1) {
            Console.WriteLine(dop1 + " помогает");
            foreach (Owner p2 in owner)
                
            {
                if (dop1 == p2.getAgenccy())
                    {


                    Console.WriteLine(p2.getFIO());
                       

                    }   
            }
            

        }*/

        public void WriteLine(string filename, ref List<Owner> owner)
        {
            FileStream file1 = new FileStream(filename, FileMode.Create);
            StreamWriter writer = new StreamWriter(file1);

            foreach (Owner p in owner)
            {
                writer.Write("Фамилия:" + p.getFIO() + "\nТелефон:" + p.getPhone() + "\n");
            }
            writer.Close();
            file1.Close();
        }

        /*void ISaveManager.WriteLine(string filename, ref List<Object1> obgect1)
        {
            throw new NotImplementedException();
        }*/

        public static void InputDop(ref List<Owner> owner)
        {

            string a1 = "aaa";
            string a2 = " ";


            owner.Add(new Owner(a1, a2, ref owner) { });

            foreach (Owner p in owner)
            {
                if (p.getFIO() == "aaa")
                {
                    owner.Remove(p);
                    break;
                }
            }

        }

        public void Write(ISaveManager man)
        {
            man.WriteLine("Фамилия:" + getFIO() + "\nТелефон:" + getPhone() + "\n");
        }

        public static void view(ref List<Owner> owner)
        {
            foreach (Owner p in owner)
            {
                Console.WriteLine("Фамилия:" + p.getFIO() + "\nТелефон:" + p.getPhone() + "\n*\n");
            }
        }

       public class Loader : IReadableObjectLoader
        {

            public Loader() { }
            public IReadableObject Load(ILoadManager man)
            {
                return new Owner(man);
            }

        }
    }
}
