using System.Collections;

namespace Lesson2_Stack
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack");

            #region 知识点一 栈的本质
            //Stack是一个C#封装好的类
            //它的本质是object[]数组，只是封装了特殊的存储规则

            //Stack是栈存储容器，是一种先进后出的数据结构
            #endregion

            #region 知识点二 申明
            //需要引用命名空间using System.Collections;
            Stack stack = new Stack();
            
            #endregion

            #region 知识点三 增取查改
            //增(压栈)
            stack.Push(1);
            stack.Push("123");
            stack.Push(true);
            stack.Push(1.2f);



            //取(弹栈)
            //栈中不存在删除的概念，只有弹栈
            object v = stack.Pop();
            Console.WriteLine(v);

            v = stack.Pop();
            Console.WriteLine(v);


            //查
            //1.栈无法查看指定位置的 元素
            // 只能查看栈顶的元素
            v = stack.Peek();
            Console.WriteLine(v);

            v = stack.Peek();
            Console.WriteLine(v);

            //2.查看元素是否存在于栈中
            if (stack.Contains("123"))
            {
                Console.WriteLine("存在");
            }



            //改
            //栈无法改变其中的元素 只能压和弹
            //必须要改的情况，只能清空
            stack.Clear();
            stack.Push(1);
            stack.Push("123");
            stack.Push(true);
            stack.Push(1.2f);
            stack.Push("哈哈哈");

            #endregion

            #region 知识点四 遍历
            //1.长度
            Console.WriteLine(stack.Count);
            //2.用foreach遍历
            //遍历出来的顺序 从栈顶到栈底
            foreach (object item in stack)
            {
                Console.WriteLine(item);
            }


            //3.还有一种遍历方式
            // 将栈转换为object数组
            // 遍历出来的顺序 也是从栈顶到栈底
            object[] arr = stack.ToArray();
            for(int i =0; i< arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }


            Console.WriteLine(stack.Count);
            //4.循环弹栈
            while(stack.Count > 0)
            {
                object o = stack.Pop();
                Console.WriteLine(o);
            }
            Console.WriteLine(stack.Count);
            #endregion

            #region 知识点五 装箱拆箱
            //用万物之父来存储数据，自然存在装箱拆箱
            //往其中进行值类型存储的时候就是在装箱
            //当将值类型对象取出来使用时，就存在拆箱
            #endregion

        }
    }
}
