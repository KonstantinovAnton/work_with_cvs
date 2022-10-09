using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_cvs
{
    public class workWithCsv
    {
       public struct lenghtValues
        {
            public double km, m, miles, feet, yards, inches, versts;

            public string concat()
            {
                return km.ToString() + ";" + m.ToString() + ";" + miles.ToString() + ";" + feet.ToString() + ";" + yards.ToString() + ";" + inches.ToString() + ";" + versts.ToString();
            }
        }


        // Чтение записей
      public static void getData(string path, List<lenghtValues> L)
        {
            int count = -1;

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {

                    count++;
                    if (count == 0)
                    {
                        string[] arrayPsevdo = sr.ReadLine().Split(';');
                        continue;
                    }

                    string[] array = sr.ReadLine().Split(';');


                    for (int i = 0; i < array.Length; i++)
                    {
                        try
                        {
                            array[i] = array[i].Replace(',', '.');
                            Convert.ToDouble(array[i]);
                        }
                        catch
                        {
                            array[i] = "0";
                        }
                    }

                    
                    L.Add(new lenghtValues()
                    {
                        km = Convert.ToDouble(array[0]),
                        m = Convert.ToDouble(array[1]),
                        miles = Convert.ToDouble(array[2]),
                        feet = Convert.ToDouble(array[3]),
                        yards = Convert.ToDouble(array[4]),
                        inches = Convert.ToDouble(array[5]),
                        versts = Convert.ToDouble(array[6])
                    });
                }
            }
        }

    

        // Вставка записей
       public static void inputData(string path, List<lenghtValues> L)
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {

               sw.WriteLine("Километры;Метры;Мили;Футы;Ярды;Дюймы;Версты");
                foreach (lenghtValues item in L)
                {
                    sw.WriteLine(item.concat());
                }
            }
        }
    }
}
