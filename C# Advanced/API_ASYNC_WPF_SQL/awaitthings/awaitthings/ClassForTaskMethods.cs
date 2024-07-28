using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace awaitthings
{
    internal class ClassForTaskMethods
    {

        public async void Main()
        {
            await FirstTaskMethod();
            string result = await SecondTaskMethod();

        }

        public async Task FirstTaskMethod()
        {
            await Task.Delay(10000);
        }

        public async Task<string> SecondTaskMethod()
        {
            return "test string";
        }

        public async Task<string> ThirdTaskMethod()
        {
            return "test string2";
        }

    }
}
