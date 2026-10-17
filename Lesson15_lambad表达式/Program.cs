namespace Lesson15_lambad表达式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("lambad表达式");

            #region 知识点一 什么是lambad表达式
            //可以将lambad表达式 理解为匿名函数的简写
            //它除了写法不同 使用上和匿名函数一样
            //都是和委托或事件 配合使用的 
            #endregion

            #region 知识点二 lambad表达式语法
            //匿名函数
            //delegate (参数列表)
            //{

            //};

            //lambad表达式
            //(参数列表) =>
            //{
            //    //函数体
            //};
            #endregion

            #region 知识点三 使用
            //1.无参无返回
            Action a = () =>
            {
                Console.WriteLine("无参无返回值的lambad表达式");
            };
            a();
            //2.有参
            Action<int> a2 = (int value) =>
            {
                Console.WriteLine("有参数的lambad表达式{0}",value);
            };
            a2(100);
            //3.甚至参数类型都可以省略 参数类型和委托或事件容器一致
            Action<int> a3 = (value) =>
            {
                Console.WriteLine("省略参数类型的写法{0}",value);
            };
            a3(666);
            //4.有返回值
            Func<string, int> a4 = (value) =>
            {
                Console.WriteLine("有返回值有参数的lambad表达式");
                return 1;
            };
            Console.WriteLine(a4("123"));
            //其他传参使用等和匿名函数一样
            //缺点也一样
            #endregion

            Test t = new Test();
            t.DoSomthing();
        }
    }
    #region 知识点四 闭包
    //内层的函数可以引用包含在它外层的函数的变量
    //即使外层函数的执行已经终止
    //注意：
    //该变量提供的值并非变量创建时的值，而是父函数范围内的最终值

    class Test
    {
        public event Action action;

        public Test()
        {
            int value = 10;
            //这里就形成了闭包
            //因为 当构造函数执行完毕时 其中申明的临时变量value的生命周期被改变了
            action = () =>
            {
                Console.WriteLine(value);
            };
            for (int i = 0; i < 10; i++)
            {
                //此index 非彼index
                int index = i;
                action += () =>
                {
                    Console.WriteLine(index);
                };
            }
        }
        public void DoSomthing()
        {
            action();
        }
    }
    #endregion
}
