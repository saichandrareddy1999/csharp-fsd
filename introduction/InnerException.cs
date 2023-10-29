//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace introduction
//{
//    public class InnerException
//    {
//        public static void Main()
//        {
//            try
//            {
//                Console.WriteLine("Enter First Number : ");
//                int FN = Convert.ToInt32(Console.ReadLine());
//                Console.WriteLine("Enter Second Number : ");
//                int SN = Convert.ToInt32(Console.ReadLine());

//                int Result = FN / SN;
//                Console.WriteLine("result = {0}", Result);
//                Console.ReadLine();
//            }
//            catch (Exception ex)
//            {
//                string FilePath = @"C:\Users\dell\OneDrive\Desktop\data.txt";
//                if (File.Exists(FilePath))
//                {
//                    StreamWriter streamWriter = new StreamWriter(FilePath);
//                    streamWriter.Write(ex.GetType().Name);
//                    streamWriter.WriteLine();
//                    streamWriter.Write(ex.StackTrace);
//                    streamWriter.Close();
//                    Console.WriteLine("There is a problem , please try agian");
//                    Console.WriteLine(ex.Message);

//                }
//                else
//                {
//                    throw new FileNotFoundException(FilePath + " is not present", ex);
//                }

//                // null pointer , format exception , overflow exception , arithmetic exception

                


//            }

//        }
//    }
//}
