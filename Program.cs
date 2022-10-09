using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace work_with_cvs
{
    class Program
    {

        static void Main(string[] args)
        {
            

            try
            {
                List<workWithCsv.lenghtValues> lv = new List<workWithCsv.lenghtValues>();
                workWithCsv.getData("dataLenght.csv", lv) ;
                List<workWithCsv.lenghtValues> newLV = calcAllValues(lv);
                workWithCsv.inputData("dataLenght.csv", newLV);

                Console.WriteLine("Длины успешно посчитаны и добавлены в файл"); 
            }
            catch
            {
                Console.WriteLine("Поймано исключение");
                Console.WriteLine("Необходимо поместить файл dataLength в Debug или верно указать относительный путь");
            }
            Console.ReadKey();
        }
    
        static List<workWithCsv.lenghtValues> calcAllValues(List<workWithCsv.lenghtValues> L)
        {
            List<workWithCsv.lenghtValues> newLV = new List<workWithCsv.lenghtValues>();

            foreach (workWithCsv.lenghtValues item in L)
            {
                newLV.Add(calcRowValues(item));
            }

            return newLV;
        }

        static workWithCsv.lenghtValues calcRowValues(workWithCsv.lenghtValues lv)
        {
           switch(findNotNull(lv))
            {
                case 0:
                    lv.m = 0;
                    lv.miles = lv.km  * 0.621371;
                    lv.feet = lv.km * 3280.84;
                    lv.yards = lv.km * 1093.61;
                    lv.inches = lv.km * 39370.1;
                    lv.versts = lv.km * 0.937383;
                    break;
                case 1:
                    lv.km = 0;
                    lv.miles = lv.m / 1000 * 0.621371;
                    lv.feet = lv.m  / 1000 * 3280.84;
                    lv.yards = lv.m / 1000 * 1093.61;
                    lv.inches = lv.m / 1000* 39370.1;
                    lv.versts = lv.m /1000 *0.937383;
                    break;
                case 2:
                    lv.km = (int)(lv.miles * 1.60934) / 1;
                    lv.m = (int)(((lv.miles * 1.60934) - lv.km) * 1000);
                    lv.feet = (lv.km + lv.m / 1000) * 3280.84;
                    lv.yards = (lv.km + lv.m / 1000) * 1093.61;
                    lv.inches = (lv.km + lv.m / 1000) * 39370.1;
                    lv.versts = (lv.km + lv.m / 1000) * 0.937383;
                    break;

                case 3:
                    lv.km = (int)(lv.feet * 0.0003048) / 1;
                    lv.m = (int)(lv.feet * 0.3048) / 1;
                    lv.miles = lv.m * 0.000621371;
                    lv.yards = lv.m / 1000 * 1093.61;
                    lv.inches = lv.m / 1000 * 39370.1;
                    lv.versts = lv.m /1000 *0.937383;
                    break;

                case 4:
                    lv.km = (int)(lv.yards * 0.0009144) / 1;
                    lv.m = (int)((lv.yards * 0.0009144) - lv.km) * 1000;
                    lv.miles = lv.km * 0.621371;
                    lv.feet = lv.km * 3280.84;
                    lv.inches = lv.km * 39370.1;
                    lv.versts = lv.km * 0.937383;
                    break;

                case 5:
                    lv.km = (int)(lv.inches * 0.0000254) / 1;
                    lv.m = (int)((lv.inches * 0.0254));
                    lv.miles = lv.m / 1000 * 0.621371;
                    lv.feet = lv.m /1000 * 3280.84;
                    lv.yards = lv.m / 1000* 1093.61;
                    lv.versts = lv.m / 1000 * 0.937383;
                    break;
                case 6:
                    lv.km = (int)(lv.versts * 1.0668) / 1;
                    lv.m = (int)(((lv.versts * 1.0668) - lv.km) * 1000);
                    lv.inches = (lv.km  + lv.m/ 1000) * 39370.1;
                    lv.miles = (lv.km + lv.m / 1000) * 0.621371;
                    lv.feet = (lv.km + lv.m / 1000) * 3280.84;
                    lv.yards = (lv.km + lv.m / 1000) * 1093.61;
                    break;
                case 10:
                    lv.miles = (lv.km + (lv.m * 0.001)) * 0.621371;
                    lv.feet = (lv.km + (lv.m * 0.001)) * 3280.84;
                    lv.yards = (lv.km + (lv.m * 0.001)) * 1093.61;
                    lv.inches = (lv.km + (lv.m * 0.001)) * 39370.1;
                    lv.versts = (lv.km + (lv.m * 0.001)) * 0.937383;
                    break;
                case -1:
                    lv.m = -1;
                    lv.km = -1;
                    lv.miles = -1;
                    lv.feet = -1;
                    lv.yards = -1;
                    lv.inches = -1;
                    lv.versts = -1;
                    break;
            }

            return lv;
        }

        static int findNotNull(workWithCsv.lenghtValues lv)
        {
            if (lv.m != 0 && lv.km != 0) return 10;
            if (lv.km != 0) return 0;
            if (lv.m != 0) return 1;
            if (lv.miles != 0) return 2;
            if (lv.feet != 0) return 3;
            if (lv.yards != 0) return 4;
            if (lv.inches != 0) return 5;
            if (lv.versts != 0) return 6;

            return - 1;
        }
    }
}
