using System.Collections;

namespace Lesson3_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue练习题");
            
            #region 练习题一
            //使用队列存储消息，一次性存10条信息，每隔一段时间打印一条信息
            //控制台打印信息要有明显停顿感
            Queue queue = new Queue();
            queue.Enqueue("消息1");
            queue.Enqueue("消息2");
            queue.Enqueue("消息3");
            queue.Enqueue("消息4");
            queue.Enqueue("消息5");   
            queue.Enqueue("消息6");
            queue.Enqueue("消息7");
            queue.Enqueue("消息8");
            queue.Enqueue("消息9");   
            queue.Enqueue("消息10");

            int updateIndex = 1;
            while (true)
            {
                if(updateIndex % 99999999 == 0)
                {
                    if(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                        updateIndex = 0;
                    }
                    
                }
                ++updateIndex;
            } 
            #endregion
        }
    }
}
