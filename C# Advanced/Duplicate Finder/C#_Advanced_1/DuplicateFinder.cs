using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Immutable;

namespace C__Advanced
{
    public class DuplicateFinder
    {
        public static List<char> FindDuplicates(char[] charArray)
        {
            HashSet<char> uniqueChars = new HashSet<char>();
            List<char> duplicates = new List<char>();

            /*            
              If the character is successfully added, it means it's a unique character.
              If the character is not added (because it already exists in the HashSet), 
              it means it's a duplicate character. In this case, we add it to the duplicates list.                       
            */

            foreach (char c in charArray)
            {
                if (!uniqueChars.Add(c))
                {
                    if (!duplicates.Contains(c))  //one found duplicate is enough
                    {
                        duplicates.Add(c);
                    }
                }
            }

            return duplicates;
        }

        public static char[] FindDuplicatesOnlyWithArray(char[] charArray)
        {
            Array.Sort(charArray); //sort the array

            for (int i = 0; i < charArray.Length; i++)  //iterate the array
            {
                if (i > 0)
                {
                    if (charArray[i] == charArray[i - 1]) //if the index 1 or higher then check if the previous one the same character
                    {
                        if (i > 1) 
                        {
                            if (charArray[i] == charArray[i - 2]) //if the index 2 or higher then check if the previous from the previous one the same character - don't print multiple times the same.
                            {
                                Console.WriteLine(charArray[i]);
                            }
                        }
                    }
                }
                else 
                {
                   Console.WriteLine(charArray[i]);
                }


            }

            return [];
        }
    }
}
