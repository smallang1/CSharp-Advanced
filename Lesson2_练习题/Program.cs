using System.Collections;
using System.ComponentModel;

namespace Lesson2_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack练习题");

            #region 练习题一
            //请简述栈的存储规则
            //先进后出
            #endregion

            #region 练习题二
            //写一个方法计算任意一个数的二进制数
            //使用栈结构方式存储，之后打印出来
            Calc(10);
            Calc(2);
            Calc(3);
            #endregion
        }

        static void Calc(uint num)
        {
            Console.Write("{0}的二进制是: ", num);
            Stack stack = new Stack();

            while (true)
            {
                stack.Push(num % 2);
                num /= 2;
                if (num == 1)
                {
                    stack.Push(num);
                    break;
                }
            }
            
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
