using System;
using System.Diagnostics;
using System.Linq;
namespace Lab3APPOO
{
     public class Telefoane
     {
          public double Pretul;
          public string Modelul;

          public Telefoane() { }
          public Telefoane(string _Model, int _Pret)
          {
               Modelul = _Model;
               Pretul = _Pret;
          }
          public static Telefoane ReadTelefoane(Telefoane _Telefoane)
          {
               Console.Write("Introduceti Modelul : ");
               _Telefoane.Modelul = Console.ReadLine();
               Console.Write("Introduceti Pretul  : ");
               _Telefoane.Pretul = Convert.ToDouble(Console.ReadLine());
               return _Telefoane;
          }
          public static void WriteTelefoane(Telefoane _Telefoane)
          {
               Console.WriteLine("\nModelul : "+_Telefoane.Modelul);
               Console.WriteLine("Pretul : "+_Telefoane.Pretul+ "\n");

          }
          
     }
}