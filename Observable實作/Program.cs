using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Observable<int> observable = new Observable<int>((ob) =>
                {
                    ob.Next(1);
                    ob.Next(2);
                    ob.Next(3);
                    ob.Complete();
                });



            //observable.Subscribe((num) => Console.WriteLine(num));


            //Observable<int> observable1 = Observable<int>.From(new int[] { 1, 2, 3, 4, 5 });

            //observable1.Subscribe((num) => Console.WriteLine(num));

            //Observable<int> observable2 = Observable<int>.Of(4, 5, 6, 7, 8);

            //observable2.Subscribe(Console.WriteLine);

            Observer<int> observer = new Observer<int>((num) => Console.WriteLine(num));

            //observable.Subscribe(observer);


            //observer.Next(1);

            //Observer<string> jsonObserver = new Observer<string>(Console.WriteLine);
            //string url = "https://mocki.io/v1/182470f2-6fb7-4990-b929-fcc08a3f3b89";
            //HttpRequest request = new HttpRequest();
            //request.Get(url).Subscribe(data =>
            //{
            //    Console.WriteLine(data);
            //});

            //Subject<int> subject = new Subject<int>(ob => 
            //{
            //    ob.Next(0);
                
            //});

            //subject.Subscribe(data =>
            //{
            //    Console.WriteLine($"callback function: {data}");
            //});

            //subject.Next(1);
            //subject.Next(2);


            CustomEventHandler<string> eventHandler = new CustomEventHandler<string>();

            eventHandler += Console.WriteLine;
            eventHandler += SayHello;
            
            ClassA a = new ClassA();
            a.SayHi("Hi");


            Console.ReadKey();
        }

        public static void SayHello(string s) 
        {
            Console.WriteLine("Hello!");
            Console.WriteLine(s);
        }
    }
}
