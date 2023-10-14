//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace introduction
//{
//    /// <summary>
//    /// delegates makes implementation of observer design pattern simple , subscriber/publish pattern
//    /// </summary>
//    public delegate void SampleDelegate();
//    public  class MulticastDelegate
//    {
//        //public static void Main()
//        {
//            SampleDelegate del1, del2, del3, del4;
//            del1 = new SampleDelegate(SampleMethod1);
//            del2 = new SampleDelegate(SampleMethod2);
//            del3 = new SampleDelegate(SampleMethod3);
//            del4 = del1 + del2 + del3 - del2;
//            del4();

//            //or

//            SampleDelegate del = new SampleDelegate(SampleMethod1);
//            del += SampleMethod2;
//            del += SampleMethod3;
//            del();
//            //removal del

//            del -= SampleMethod2;

//        }
//        public static void SampleMethod1()
//        {
//            Console.WriteLine("Sample method 1 invoked");
//        }
//        public static void SampleMethod2()
//        {
//            Console.WriteLine("Sample method 2 invoked");
//        }
//        public static void SampleMethod3()
//        {
//            Console.WriteLine("Sample method 3 invoked");
//        }
//        public static void SampleMethod4()
//        {
//            Console.WriteLine("Sample method 4 invoked");
//        }
//    }
//}
