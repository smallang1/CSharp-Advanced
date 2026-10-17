namespace Lesson11_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型栈和队列 练习题");

            #region 练习题
            //总结：数组、List、Dictionary、Stack、Queue、LinkedList
            //这些存储容器，应该如何选择去使用他们

            #region 答案
            //普通线性表
            //数组，List，LinkedList
            //数组：固定不变的一组数组
            //List：经常改变，经常通过下标查找
            //LinkedList：不确定长度，经常临时插入改变，查找不多

            //先进后出：Stack
            //对于一些可以利用先进后出存储特点的逻辑
            //比如：UI界面的显隐规则

            //先进先出：Queue
            //对于一些可以利用先进先出存储特点的逻辑
            //比如：消息队列，有了就往里面放，慢慢依次处理

            //键值对：Dictionary
            //需要频繁查找的，有对应关系的数据
            //比如一些数据存储  id对应数据内容
            //道具ID --> 道具对象
            //怪物ID --> 怪物对象
            #endregion

            #endregion
        }
    }
}
