using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArr1 = new int[] { 8, 6, 8, 2, 3, 5, 7, 9 };
            int[] intArr2 = new int[] { 3, 2, 9, 10, 5, 25, 50, 30, 1 };

            //sort the arrays
            Array.Sort(intArr1); Array.Sort(intArr2);

            int[] matchedArray = new int[10];
            int[] newSets = new int[10];
            if (intArr1.Length > intArr2.Length)
            {
                matchedArray = FindMatchingIntegers(intArr1, intArr2);
                newSets = FindMatchingSets(intArr1, intArr2);
            }
            else
            {
                matchedArray = FindMatchingIntegers(intArr2, intArr1);
                //search using binary serach
                newSets = FindMatchingSets(intArr2, intArr1);
            }

            Console.WriteLine("[{0}]", string.Join(", ", matchedArray));

            Console.WriteLine();
            Console.WriteLine("[{0}]", string.Join(", ", newSets));

            Console.ReadKey();
        }

        /*
         * linear search array1 using array2 as key
         */
        static int[] FindMatchingIntegers(int[] array1, int[] array2)
        {
            Array.Sort(array1);
            Array.Sort(array2);

            int[] newArray = new int[10];
            int index = 0;

            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < array1.Length; j++)
                {
                    if (array1[j] == array2[i])
                    {
                        newArray[index] = array1[j];
                        index++;
                        break;
                    }
                }
            }
            return newArray;
        }

        /*
         * binary search array1 using array2 as key
         */
        static int[] FindMatchingSets(int[] array1, int[] array2)
        {
            int[] newArray = new int[10];
            int index = 0;

            for (int i = 0; i < array2.Length; i++)
            {
                int indexOf = BinarySearch(array1, array2[i]);
                if(indexOf > 0)
                {
                    newArray[index] = array2[i];
                    index++;
                }
            }

            return newArray;
        }

        static int BinarySearch(int[] integerArray, int key)
        {
            int start = 0, mid = 0, last = integerArray.Length - 1;
            while(start <= last)
            {
                mid = (start + last) / 2;
                if(key == integerArray[mid])
                {
                    return mid;
                }
                else if (key > integerArray[mid])
                {
                    start = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }
            }
            return -1;
        }
    }
}
