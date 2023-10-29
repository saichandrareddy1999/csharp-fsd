//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;

//namespace introduction
//{
//    public class ExceptionHandling
//    {
//        static void Main()
//        {
//            StreamReader streamReader = null;
//            try
//            {
//                streamReader = new StreamReader(@"C:\Users\dell\OneDrive\Desktop\data.txt");
//                Console.WriteLine(streamReader.ReadToEnd());
//            }
//            catch (FileNotFoundException ex)
//            {
//                // Log the details to DB which has specific details and this should be top before generic catch
//                Console.WriteLine("Please check if file exists {0}", ex.FileName);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            finally
//            {
//                if (streamReader != null)
//                {
//                    streamReader.Close();
//                }
//                Console.WriteLine("finally block");
//            }
//        }

//    }
//}
