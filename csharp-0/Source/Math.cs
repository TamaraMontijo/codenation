using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
          List<int> fibonacci = new List<int> { 0, 1 };
          int previousNumber = 0;
          int currentNumber = 1;
          int sum = previousNumber + currentNumber;


          for (int i = 2; fibonacci[i - 1] + fibonacci[i - 2] <= 350; i++)
          {
              fibonacci.Add(sum);
              previousNumber = currentNumber;
              currentNumber = sum;
              sum = previousNumber + currentNumber;
          }
          return fibonacci;
        }

        public bool IsFibonacci(int numberToTest)
        {
           return Fibonacci().Contains(numberToTest);
        }
    }
}
