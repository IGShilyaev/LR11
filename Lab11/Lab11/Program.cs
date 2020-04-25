using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using ClassLibrary10;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList sl = new SortedList();
            Library lb1 = new Library("A", 1950, 52);
            Library lb2 = new Library("B", 1990, 50);
            ShipComp sc1 = new ShipComp("C", 1950, 200);
            ShipComp sc2 = new ShipComp("D", 1975, 350);
            InsuranceComp ic1 = new InsuranceComp("E", 1990, 52);
            Plant pl1 = new Plant("F", 2000, 300);
            Plant pl2 = new Plant("G", 1950, 500);
            Organization org1 = new Organization("H", 1980);

            sl.Add(lb1.Name + "-" + lb1.Founded ,lb1);
            sl.Add(lb2.Name + "-" + lb2.Founded, lb2);
            sl.Add(sc1.Name + "-" + sc1.Founded, sc1);
            sl.Add(sc2.Name + "-" + sc2.Founded, sc2);
            sl.Add(ic1.Name + "-" + ic1.Founded, ic1);
            sl.Add(pl1.Name + "-" + pl1.Founded, pl1);
            sl.Add(pl2.Name + "-" + pl2.Founded, pl2);
            sl.Add(org1.Name + "-" + org1.Founded, org1);
      

            int operation;
            bool stop = false;
            #region demo1
            ListFunctions();
            do
            {
                Console.WriteLine("Введите номер нужной операции");
                operation = EnterIntNumber();
                switch (operation)
                {
                    case 0:
                        {
                            Console.WriteLine("Работа завершена");
                            stop = true;
                            break;
                        }
                    case 1:
                        {
                            EngsAtEveryPlant(sl);
                            break;
                        }
                    case 2:
                        {
                            int libs = NumberOfLibs(sl);
                            Console.WriteLine($"В коллекции {libs} библиотек");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"Сумма страховых фондов = {InshFondSum(sl)} млн");
                            break;
                        }
                    case 4:
                        {
                            foreach (DictionaryEntry x in sl) 
                            {
                                Organization temp =(Organization) x.Value;
                                temp.VShow();
                                Console.WriteLine(); 
                            }
                            break;
                        }
                    case 5:
                        {
                            AddElement(ref sl);
                            break;
                        }
                    case 6:
                        {
                            DeleteElement(ref sl);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Операции с данным номером не существует. Введите другой номер");
                            break;
                        }
                }
            } while (!stop);
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();

            #endregion

            List<Organization> sl2 = new List<Organization>();
            sl2.Add(lb1);
            sl2.Add(lb2);
            sl2.Add(sc1);
            sl2.Add(sc2);
            sl2.Add(ic1);
            sl2.Add(pl1);
            sl2.Add(pl2);
            sl2.Add(org1);
            stop = false;

            #region demo2
            ListFunctions();
            do
            {
                Console.WriteLine("Введите номер нужной операции");
                operation = EnterIntNumber();
                switch (operation)
                {
                    case 0:
                        {
                            Console.WriteLine("Работа завершена");
                            stop = true;
                            break;
                        }
                    case 1:
                        {
                            EngsAtEveryPlant(sl2);
                            break;
                        }
                    case 2:
                        {
                            int libs = NumberOfLibs(sl2);
                            Console.WriteLine($"В коллекции {libs} библиотек");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine($"Сумма страховых фондов = {InshFondSum(sl2)} млн");
                            break;
                        }
                    case 4:
                        {
                            foreach (Organization x in sl2)
                            {
                                x.VShow();
                                Console.WriteLine();
                            }
                            break;
                        }
                    case 5:
                        {
                            AddElement(ref sl2);
                            break;
                        }
                    case 6:
                        {
                            DeleteElement(ref sl2);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Операции с данным номером не существует. Введите другой номер");
                            break;
                        }
                }
            } while (!stop);
            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region demo 1 + 2

            SortedList slClone = (SortedList) sl.Clone();
            slClone.Add("zero", 0);
            Console.WriteLine("Поиск добавленного в клон коллекции элемента:");
            if (sl.ContainsValue(0)) Console.WriteLine("Элемент найден в оригинальной коллекции");
            else Console.WriteLine("Элемент не найден в оригинальной коллекции");
            if (slClone.ContainsValue(0)) Console.WriteLine("Элемент найден в клоне коллекции");
            else Console.WriteLine("Элемент не найден в клоне коллекции");
            Console.WriteLine();

            Plant extraplant = new Plant();
            List<Organization> sl2Clone = new List<Organization>();
            foreach (Organization x in sl2)
            {
                Organization clone = (Organization) x.Clone();
                sl2Clone.Add(clone);
            }
            sl2Clone.Add(extraplant);
            Plant exPlantClone = (Plant) extraplant.Clone();
            Console.WriteLine("Поиск добавленного в клон коллекции элемента:");
            if (sl.ContainsValue(exPlantClone)) Console.WriteLine("Элемент найден в оригинальной коллекции");
            else Console.WriteLine("Элемент не найден в оригинальной коллекции");
            if (slClone.ContainsValue(exPlantClone)) Console.WriteLine("Элемент найден в клоне коллекции");
            else Console.WriteLine("Элемент не найден в клоне коллекции");

            Console.WriteLine("Для продолжения нажмите Enter");
            Console.ReadLine();

            #endregion

            #region demo3
            int size = 100;
            TestCollections tc = new TestCollections(size);
            Stopwatch stw = new Stopwatch();

            Organization[] arr = tc.Link.ToArray();
            Organization firstOrg = (Organization) arr[0].Clone();
            Organization middleOrg = (Organization) arr[size / 2].Clone();
            Organization lastOrg = (Organization) arr[size - 1].Clone();
            Organization absOrg = new Organization();

            Console.WriteLine("Queue<Organization>");
            stw.Start();
            if (tc.Link.Contains(firstOrg)) Console.WriteLine($"Первый элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Первый элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Link.Contains(middleOrg)) Console.WriteLine($"Средний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Средний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Link.Contains(lastOrg)) Console.WriteLine($"Последний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Последний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Link.Contains(absOrg)) Console.WriteLine($"Элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Reset();
            Console.WriteLine();

            string[] arr1 = tc.Key.ToArray();
            string firstStr = (string)arr1[0].Clone();
            string middleStr = (string)arr1[size/2].Clone();
            string lastStr = (string)arr1[size-1].Clone();
            string absStr = "???";

            Console.WriteLine("Queue<string>");
            stw.Start();
            if (tc.Key.Contains(firstStr)) Console.WriteLine($"Первый элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Первый элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Key.Contains(middleStr)) Console.WriteLine($"Средний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Средний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Key.Contains(lastStr)) Console.WriteLine($"Последний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Последний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Key.Contains(absStr)) Console.WriteLine($"Элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Reset();
            Console.WriteLine();

            Console.WriteLine("SortedDictionary<Organization, Library> /// ContainsKey");
            stw.Start();
            if (tc.Coll1.ContainsKey(firstOrg)) Console.WriteLine($"Первый элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Первый элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll1.ContainsKey(middleOrg)) Console.WriteLine($"Средний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Средний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll1.ContainsKey(lastOrg)) Console.WriteLine($"Последний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Последний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll1.ContainsKey(absOrg)) Console.WriteLine($"Элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Reset();
            Console.WriteLine();

            Library[] arr2 = new Library[size];
            tc.Coll1.Values.CopyTo(arr2, 0);
            Library firstLib = (Library) arr2[0].Clone();
            Library middleLib = (Library)arr2[size/2].Clone();
            Library lastLib = (Library)arr2[size-1].Clone();
            Library absLib = new Library();

            Console.WriteLine("SortedDictionary<Organization, Library> /// ContainsValue");
            stw.Start();
            if (tc.Coll1.ContainsValue(firstLib)) Console.WriteLine($"Первый элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Первый элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll1.ContainsValue(middleLib)) Console.WriteLine($"Средний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Средний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll1.ContainsValue(lastLib)) Console.WriteLine($"Последний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Последний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll1.ContainsValue(absLib)) Console.WriteLine($"Элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Reset();
            Console.WriteLine();


            Console.WriteLine("SortedDictionary<string, Library>");
            stw.Start();
            if (tc.Coll2.ContainsKey(firstStr)) Console.WriteLine($"Первый элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Первый элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll2.ContainsKey(middleStr)) Console.WriteLine($"Средний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Средний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll2.ContainsKey(lastStr)) Console.WriteLine($"Последний элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Последний элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Restart();
            if (tc.Coll2.ContainsKey(absStr)) Console.WriteLine($"Элемент найден, время поиска {stw.ElapsedTicks}");
            else Console.WriteLine($"Элемент не найден, время поиска {stw.ElapsedTicks}");
            stw.Reset();

            #endregion



        }

        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        static int EnterIntNumber()
        {
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) Console.WriteLine("Ошибка ввода, введите целое положительное число");
            } while (!ok);
            return n;
        }

        static void ListFunctions()
        {
            Console.WriteLine(@"1 - Количество инженеров на каждом заводе в коллекции
2 - Количество библиотек в коллекции
3 - Суммарный страховой фонд всех страховых компаний в коллекции
4 - Вывести коллекцию
5 - Добавить элемент в коллекцию
6 - Удалить элемент из коллекции
0 - Завершить работу");
        }

        #region SortedList
        static int NumberOfLibs(SortedList sortlist)
        {
            int counter = 0;
            foreach (DictionaryEntry x in sortlist) if (x.Value is Library) counter++;
            return counter;
        }
        static float InshFondSum(SortedList sortlist)
        {
            float sum = 0;
            foreach (DictionaryEntry x in sortlist) if (x.Value is InsuranceComp)
                {
                    InsuranceComp temp = (InsuranceComp)x.Value;
                    sum += temp.InshFond;
                }
            return sum;
        }
        static void EngsAtEveryPlant(SortedList sortlist)
        {
            foreach (DictionaryEntry x in sortlist) if (x.Value is Plant)
                {
                    Plant temp = (Plant)x.Value;
                    Console.WriteLine($"Количество инженеров на заводе {temp.Name} = {temp.NumberOfEng}");
                }
        }

        static void AddElement(ref SortedList sortList)
        {
            Console.WriteLine("Выберите тип организации");
            Console.WriteLine(@"1 - Библиотека
2 - Страховая компания
3 - Судостроительная компания
4 - Завод");
            int operation1 = EnterIntNumber();
            switch (operation1)
            {
                case 1:
                    {
                        AddLib(ref sortList);
                        break;
                    }
                case 2:
                    {
                        AddInsComp(ref sortList);
                        break;
                    }
                case 3:
                    {
                        AddSComp(ref sortList);
                        break;
                    }
                case 4:
                    {
                        AddPlant(ref sortList);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ошибка, неверный номер!");
                        break;
                    }
            }
        }

        static void AddLib(ref SortedList sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите количество учебников");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp.Name + "-" + temp.Founded, temp);
        }

        static void AddSComp(ref SortedList sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите количество работников");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp.Name + "-" + temp.Founded, temp);
        }

        static void AddPlant(ref SortedList sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите количество рабочих");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp.Name + "-" + temp.Founded, temp);
        }

        static void AddInsComp(ref SortedList sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите значение страхового фонда");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp.Name + "-" + temp.Founded, temp);
        }

        static void DeleteElement(ref SortedList sortList)
        {
            Console.WriteLine("Введите название элемента");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            if (sortList.ContainsKey(n + "-" + f))
            {
                sortList.Remove(n + "-" + f);
                Console.WriteLine("Удаление выполнено");
            }
            else Console.WriteLine("Элемент с данными параметрами не был найден");
        }
        #endregion
        #region List<T>
        static int NumberOfLibs(List<Organization> sortlist)
        {
            int counter = 0;
            foreach (Organization x in sortlist) if (x is Library) counter++;
            return counter;
        }
        static float InshFondSum(List<Organization> sortlist)
        {
            float sum = 0;
            foreach (Organization x in sortlist) if (x is InsuranceComp)
                {
                    InsuranceComp temp = (InsuranceComp)x;
                    sum += temp.InshFond;
                }
            return sum;
        }
        static void EngsAtEveryPlant(List<Organization> sortlist)
        {
            foreach (Organization x in sortlist) if (x is Plant)
                {
                    Plant temp = (Plant)x;
                    Console.WriteLine($"Количество инженеров на заводе {temp.Name} = {temp.NumberOfEng}");
                }
        }

        static void AddElement(ref List<Organization> sortList)
        {
            Console.WriteLine("Выберите тип организации");
            Console.WriteLine(@"1 - Библиотека
2 - Страховая компания
3 - Судостроительная компания
4 - Завод");
            int operation1 = EnterIntNumber();
            switch (operation1)
            {
                case 1:
                    {
                        AddLib(ref sortList);
                        break;
                    }
                case 2:
                    {
                        AddInsComp(ref sortList);
                        break;
                    }
                case 3:
                    {
                        AddSComp(ref sortList);
                        break;
                    }
                case 4:
                    {
                        AddPlant(ref sortList);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ошибка, неверный номер!");
                        break;
                    }
            }
        }

        static void AddLib(ref List<Organization> sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите количество учебников");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add( temp);
        }

        static void AddSComp(ref List<Organization> sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите количество работников");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp);
        }

        static void AddPlant(ref List<Organization> sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите количество рабочих");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp);
        }

        static void AddInsComp(ref List<Organization> sortList)
        {
            Console.WriteLine("Введите название");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Console.WriteLine("Введите значение страхового фонда");
            int t = EnterIntNumber();
            Library temp = new Library(n, f, t);
            sortList.Add(temp);
        }

        static void DeleteElement(ref List<Organization> sortList)
        {
            Console.WriteLine("Введите название элемента");
            string n = Console.ReadLine();
            Console.WriteLine("Введите год основания");
            int f = EnterIntNumber();
            Organization temp = new Organization(n, f);
            if (sortList.Contains(temp))
            {
                sortList.Remove(temp);
                Console.WriteLine("Удаление выполнено");
            }
            else Console.WriteLine("Элемент с данными параметрами не был найден");
        }
        #endregion

    }
}
