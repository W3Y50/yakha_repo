class Day5Solutions
//variable scope --> class / method / block
//for loop : check
//nested for loops : check
//while loop : check
//do ..while loop : check
//break an continue : check
//Ternary Operator : check

{
    class Program 
    
    {
         public static void Main(string[] args)
        {

            WhileThings obj1 = new WhileThings();
            obj1.DoSomething1();
            ForThings obj2 = new ForThings();
            obj2.DoSomething2();


        }

        class WhileThings() 
        {
            public void DoSomething1() 
            { 
                // while loop

                int i = 0;

                while (i< 5)
                {
                    Console.WriteLine($"While Iteration {i}");
                    i++;
                }
                            
                // do while loop
                int j = 0;

                do
                {
                    Console.WriteLine($"Do while Iteration {j}");
                    j++;
                }
                while (j< 5);
            }  

    }
    class ForThings()
        {
            public void DoSomething2()
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        
                        string re = (i > j) ? "i greater than j" : "i smaller than j";

                        Console.WriteLine($"Nested For Loop Iteration {i} / {j} / {re}");
                    }
                }

                for (int k = 0; k < 5; k++)
                {
                    if (k == 3) { break; }
                    
                    for (int l = 0; l < 5; l++)
                    {
                        if (l == 2) { continue; }
                        Console.WriteLine($"Nested For Loop Iteration {k} + {l}");
                    }
                }

            }
        }

    }




}
