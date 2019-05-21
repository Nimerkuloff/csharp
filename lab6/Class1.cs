using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Класс
{
    abstract class Izdelie
    {
        
        public virtual void info()
        {
            Console.WriteLine("базовый класс\n");
        }
    }
    class Detail : Izdelie
    {
        
        public override void info()
        {
            Console.WriteLine("I am detail\n");
        }
    }

    class Mechanism : Izdelie

    {
       
        public override void info()
        {
            Console.WriteLine("I am mechanism\n");
        }
    }

    class Uzel : Izdelie
    {
        
        public override void info()
        {
            Console.WriteLine("I am uzel");
        }
    }
    class Program

    {
        static void Main()
        {
            Izdelie det = new Detail(); 
            det.info(); 
            
            Izdelie mec = new Mechanism();
            mec.info();

           
            Izdelie uzel = new Uzel();
            uzel.info();

            Console.ReadLine();
        }
    }
}