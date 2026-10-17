using System.Collections;

namespace Lesson3_Queue
{
    class Test
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue");

            #region 知识点一 Queue本质
            //Queue本质是object[]数组，只是封装了特殊的存储规则

            //Queue是队列存储容器
            //队列是先进先出的数据结构
            //先进先出
            #endregion

            #region 知识点二 申明
            //需要引用命名空间 System.Collections
            Queue queue = new Queue();
            #endregion

            #region 知识点三 增取查改
            //增
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue("123");
            queue.Enqueue(true);
            queue.Enqueue(1.4f);
            queue.Enqueue(new Test());


            //取
            //队列中不存在删除的概念
            //只有取的概念 取出先加入的对象
            object v = queue.Dequeue();
            Console.WriteLine(v);
            v = queue.Dequeue();
            Console.WriteLine(v);


            //查
            //1.查看队列头部元素但不会移除
            v = queue.Peek();
            Console.WriteLine(v);
            v = queue.Peek();
            Console.WriteLine(v);

            //2.查看元素是否存在于队列中
            if (queue.Contains(1.4f))
            {
                Console.WriteLine("队列中存在");
            }



            //改
            //队列中不存在修改的概念
            //只有增的概念 先加入的对象在队尾
            //是咋要改 只能清空
            Console.WriteLine("队列长度：" + queue.Count);
            queue.Clear();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            #endregion

            #region 知识点四 遍历
            //1.长度
            Console.WriteLine("队列长度：" + queue.Count);

            //2.使用foreach遍历
            foreach (object item in queue)
            {
                Console.WriteLine(item);
            }

            //3.转成object数组
            object[] arr = queue.ToArray();
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            //4.循环出栈
            while (queue.Count > 0)
            {
                object o = queue.Dequeue();
                Console.WriteLine(o);
            }
            Console.WriteLine("队列长度：" + queue.Count);
            #endregion

            #region 知识点五 装箱拆箱
            //本质是object数组，自然存在装箱拆箱
            #endregion
        }
    }
}
