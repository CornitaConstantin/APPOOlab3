using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3APPOO
{
     class Program
     {
          HashSet<Telefoane> RemoveRangeAndAddSecondHash(HashSet<Telefoane> _HashSet1, HashSet<Telefoane> _HashSet2)
          {
               int ItemToDelete, ItemsToBeDeleted;
               var names = ShowElements(_HashSet1);
               Console.Clear();
               var i = 0;
               foreach (var item in names)
                    Console.WriteLine(i++ + " : "+item);
               Console.WriteLine("De la care element doriti sa incepeti stergerea? : ");
               ItemToDelete = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Cite elemente doriti sa mai stergeti? : ");
               ItemsToBeDeleted = Convert.ToInt32(Console.ReadLine());
               if (ItemsToBeDeleted >= (_HashSet1.Count() - ItemToDelete))
               {
                    Console.WriteLine("Nu puteti sterge mai multe elemente decit are setul,\n Introduceti un numar mai mic! : ");
                    ItemsToBeDeleted = Convert.ToInt32(Console.ReadLine());
               }
               var _itemFrist = _HashSet1.FirstOrDefault(el=>el.Modelul == names.ElementAtOrDefault(ItemToDelete));
               var _lastItem = _HashSet1.FirstOrDefault(el => el.Modelul == names.ElementAtOrDefault(ItemsToBeDeleted));
               bool _tempFlag = false;
               foreach(var item in _HashSet1.ToList())
               {
                    if (item == _itemFrist) _tempFlag = true;
                   if (_tempFlag)
                    {
                         _HashSet1.Remove(item);
                    }
                    if (item == _lastItem) _tempFlag = false;
               }
               _HashSet1.Remove(_itemFrist);
               foreach(var item in _HashSet2)
                    _HashSet1.Add(item);
               return _HashSet1;
          }
          public static HashSet<Telefoane> ModificaSet(HashSet<Telefoane> _HashSet)
          {
               int option = 1;
               while (option != 0)
               {
                    Console.Clear();
                    Console.WriteLine("Selecteaza o optiune!");
                    Console.WriteLine("1 : Stergeti datele despre un Telefon");
                    Console.WriteLine("2 : Modifica datele despre un Telefon");
                    Console.WriteLine("3 : Adauga datele despre un Telefon");
                    Console.WriteLine("0 : Inapoi");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                         case 1:
                              {
                                   int ItemToDelete = 0;
                                   var names = ShowElements(_HashSet);
                                   Console.Clear();
                                   var i = 0;
                                   foreach (var item in names)
                                        Console.WriteLine(i++ + " : " + item);
                                   Console.Write("Sterge datele despre telefonul : ");
                                   ItemToDelete = Convert.ToInt32(Console.ReadLine());
                                   _HashSet.Remove(_HashSet.FirstOrDefault(element => element.Modelul == names[ItemToDelete]));
                              }
                              break;
                         case 2:
                              {
                                   int ItemToModify = 0;
                                   var names = ShowElements(_HashSet);
                                   Console.Clear();
                                   var i = 0;
                                   foreach (var item in names)
                                        Console.WriteLine(i++ + " : " + item);
                                   Console.WriteLine("\nModificati datele despre telefonul : ");
                                   ItemToModify = Convert.ToInt32(Console.ReadLine());
                                   var TelefonToModify = _HashSet.FirstOrDefault(element => element.Modelul == names[ItemToModify]);
                                   TelefonToModify = ModifyItem(TelefonToModify);
                                   ShowElements(_HashSet);

                              }
                              break;
                         case 3:
                              {
                                   Telefoane telefoane = new Telefoane();
                                   telefoane = Telefoane.ReadTelefoane(telefoane);
                                   _HashSet.Add(telefoane);
                              }
                              break;
                    }
               }
               return _HashSet;
          }

          private static Telefoane ModifyItem(Telefoane telefoane)
          {
               int ItemToModify = 1;

               while (ItemToModify != 0)
               {
                    Console.Clear();
                    Telefoane.WriteTelefoane(telefoane);
                    Console.WriteLine("Alegeti o optiune!");
                    Console.WriteLine("1 : Modifica Modelul");
                    Console.WriteLine("2 : Modifica Pretul");
                    Console.WriteLine("0 : Inapoi");
                    ItemToModify = Convert.ToInt32(Console.ReadLine());
                    switch (ItemToModify)
                    {
                         case 1:
                              {
                                   Console.WriteLine("Introduceti noul model : ");
                                   telefoane.Modelul = Console.ReadLine();
                              }
                              break;
                         case 2:
                              {
                                   Console.WriteLine("Introduceti pretul : ");
                                   telefoane.Pretul = Convert.ToInt32(Console.ReadLine()) ;
                              }
                              break;
                    }
               }
               return telefoane;
          }

          public static List<Telefoane> FindElementsMove(HashSet<Telefoane> _HashSet)
          {
               string Model;
               List<Telefoane> _ListNewLocal = new List<Telefoane>();

               Console.WriteLine("Introduceti modelul pentru cautare! : ");
               Model = Console.ReadLine();
               foreach(var element in _HashSet)
               {
                    if (element.Modelul == Model)
                    {
                         Console.WriteLine("A fost gasit un element!");
                         Telefoane.WriteTelefoane(element);
                         Console.ReadKey();
                         _ListNewLocal.Add(element);
                         _HashSet.Remove(element);
                         return _ListNewLocal;
                    }
                    else if (element.Equals(_HashSet.Last()) && element.Modelul != Model && _ListNewLocal.Count == 0)
                    {
                         Console.WriteLine("Nu a fost gasit");
                         Console.ReadKey();
                    }
               }
               return _ListNewLocal;
          }
          public static List<string> ShowElements(HashSet<Telefoane> _HashSet)
          {
               List<string> _names = new List<string>();
               foreach (var elements in _HashSet)
               { 
                    Telefoane.WriteTelefoane(elements);
                    _names.Add(elements.Modelul);
               }
               return _names;
          }
          public static void ShowElements(List<Telefoane> _List)
          {
               foreach(var _it in _List)
                    Telefoane.WriteTelefoane(_it);
          }
          private HashSet<Telefoane> PopulateHashSet(HashSet<Telefoane> _HashSet)
          {
               int Counter = 1;
               Console.Write("Introduceti elementele primului container (minimum 4)");
               Console.Write("\n");
               while (Counter != 0)
               {
                    string _tempGrupa;
                    Telefoane _temp = new Telefoane();
                    Console.Write("Introduceti Brandul : ");
                    _tempGrupa = Console.ReadLine();
                    _temp = Telefoane.ReadTelefoane(_temp);
                    _HashSet.Add(_temp);
                    Counter++;
                    if (Counter >= 5)
                    {
                         char _decision;
                         Console.Write("Doriti sa mai adaugati un telefon?  y/n ");
                         _decision = Convert.ToChar(Console.ReadLine());
                         if (_decision == 'n' || _decision == 'N')
                         {
                              Counter = 0;
                         }
                    }

               }

               return _HashSet;
          }
          static void Main(string[] args)
          {
               bool _showChangeElementsP1 = true;
               int _Program = 0;
               Console.Clear();
               Program _this = new Program();
               HashSet<Telefoane> _HashSet = new HashSet<Telefoane>();
               HashSet<Telefoane> _HashSet2 = new HashSet<Telefoane>();
               _HashSet = _this.PopulateHashSet(_HashSet);
               Console.Clear();
               Console.WriteLine("Care program doriti sa rulati?");
               Console.WriteLine("1 : Primul");
               Console.WriteLine("2 : Al doilea");
               _Program = Convert.ToInt32(Console.ReadLine());

               switch (_Program)
               {
                    case 2:
                         {
                             
                              List<Telefoane> _List1 = new List<Telefoane>();
                              List<Telefoane> _List2 = new List<Telefoane>();
                              List<Telefoane> _List3 = new List<Telefoane>();
                              List<Telefoane> _ListPromovati = new List<Telefoane>();
                             

                              int option = 1;
                              while (option != 0)
                              {
                                   Console.Clear();
                                   Console.WriteLine("Selecteaza o optiune !");
                                   Console.WriteLine("1 : Afiseaza continutul primului container");
                                   if (_List1.Count == 0)
                                        Console.WriteLine("2 : Cauta un telefon in primul container si mutal in al 2-lea ");
                                   else Console.WriteLine("2 : Afiseaza continutul celui de al doilea container ");
                                   if (_List1.Count > 0)
                                   {
                                        Console.WriteLine("3 : Sorteaza telefoanele dupa cresterea pretului");
                                   }
                                   if (_List1.Count > 0)
                                   {
                                        if (_List2.Count == 0) Console.WriteLine("4 : Arunca toate telefoanele din ambele containere in unul singur ");
                                        else Console.WriteLine("4 : Vizualizeaza continutul celui de al 3-lea container");
                                   }
                                   if (_List2.Count > 0)
                                   {
                                        Console.WriteLine("5 : Cauta telefoane cu pretul mai mare de 200 in containerul 3");
                                        Console.WriteLine("6 : Cauta un telefon in containerul 3");
                                   }
                                   Console.Write("0 : Iesire");
                                   option = Convert.ToInt32(Console.ReadLine());
                                   switch (option)
                                   {
                                        case 1:
                                             {
                                                  ShowElements(_HashSet);
                                                  Console.ReadKey();
                                             }
                                             break;
                                        case 2:
                                             {
                                                  if (_List1.Count == 0)
                                                  {
                                                       _List1 = FindElementsMove(_HashSet);
                                                  }
                                                  else
                                                  {
                                                       ShowElements(_List1);
                                                       Console.ReadKey();
                                                  }
                                             }
                                             break;
                                        case 3:
                                             {
                                                  _List1.OrderBy(obj => obj.Pretul);
                                                  //_HashSet.OrderBy(obj => obj.Pretul);
                                                  Console.WriteLine("Succes!");
                                                  Console.ReadKey();
                                             }
                                             break;
                                        case 4:
                                             {
                                                  if (_List2.Count == 0)
                                                  {
                                                       foreach (var element in _List1)
                                                       {
                                                            _List2.Add(element);
                                                       }
                                                       foreach (var element in _HashSet)
                                                       {
                                                            _List2.Add(element);
                                                       }
                                                  }
                                                  else
                                                  {
                                                       ShowElements(_List2);
                                                       Console.ReadKey();
                                                  }
                                             }
                                             break;
                                        case 5:
                                             {
                                                  if (_List2.Count > 0)
                                                  {
                                                       _List3 = new List<Telefoane>(_List2.Where(element => element.Pretul >= 5));
                                                       Console.WriteLine("{0} telefoane cu pretul mai mare de 200!", _List3.Count);
                                                       Console.Clear();
                                                       ShowElements(_List3);
                                                       Console.ReadKey();
                                                  }
                                             }
                                             break;
                                        case 6:
                                             {
                                                  string Nume = string.Empty;
                                                  Console.WriteLine("Introduceti modelul telefonului : ");
                                                  Nume = Console.ReadLine();
                                                  var _Gasit = _List2.FirstOrDefault(element => element.Modelul == Nume);
                                                  Console.Clear();
                                                  if (_Gasit != null)
                                                       Telefoane.WriteTelefoane(_Gasit);
                                                  else Console.WriteLine("Nu a fost gasit nici un element");
                                                  Console.ReadKey();
                                             }
                                             break;
                                   }
                              }
                         }
                         break;
                    case 1:
                         {
                              int option = 1;
                              while (option != 0)
                              { 
                                   Console.Clear();
                                   Console.WriteLine("Selecteaza o optiune !");
                                   Console.WriteLine("1 : Afiseaza continutul primului container");
                                   if (_HashSet2.Count == 0)
                                        Console.WriteLine("2 : Adauga un container cu telefoane");
                                   else
                                        Console.WriteLine("2 : Afiseaza continutul celui de al doilea container ");
                                   Console.WriteLine("3 : Schimba elemente dintr-un set");
                                   if (_HashSet2.Count > 0 && _showChangeElementsP1)
                                   Console.WriteLine("4 : Sterge elemente din primul set si adauga elementele din setul 2 in primul!");
                                   Console.Write("0 : Iesire");
                                   option = Convert.ToInt32(Console.ReadLine());
                                   switch (option)
                                   {
                                        case 1:
                                             {
                                                  ShowElements(_HashSet);
                                                  Console.ReadKey();
                                             }
                                             break;
                                        case 2:
                                             {
                                                  if (_HashSet2.Count == 0)
                                                  {
                                                       _HashSet2 = _this.PopulateHashSet(_HashSet2);
                                                  }else
                                                  {
                                                       ShowElements(_HashSet2);
                                                       Console.ReadKey();
                                                  }

                                             } break;
                                        case 3:
                                             {
                                                  var _tempChoser = 0;
                                                  Console.Clear();
                                                  Console.WriteLine("Care container doriti sa-l modificati?");
                                                  Console.WriteLine("1 : Primul Container");
                                                  if(_HashSet2.Count != 0)Console.WriteLine("2 : Al doilea Container");
                                                  _tempChoser = Convert.ToInt32(Console.ReadLine());
                                                  switch (_tempChoser)
                                                  {
                                                       case 1: { ModificaSet(_HashSet); } break;
                                                       case 2: { if (_HashSet2.Count != 0) ModificaSet(_HashSet2); } break;
                                                  }
                                                  
                                             } break;
                                        case 4:
                                             {
                                                  if (_HashSet2.Count > 0 && _showChangeElementsP1)
                                                  {
                                                      _HashSet = _this.RemoveRangeAndAddSecondHash(_HashSet, _HashSet2);
                                                       _showChangeElementsP1 = false;
                                                  }

                                             } break;

                                   }
                              }
                         } break;
               }
          }
     }
}
