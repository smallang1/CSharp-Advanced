namespace Lesson13_事件
{
    #region 知识点一 事件是什么
    //事件是基于委托的存在
    //事件是委托的安全包裹
    //让委托的使用更具有安全性
    //事件 是一种特殊的变量类型
    #endregion

    #region 知识点二 事件的使用
    //语法：
    //访问修饰符 event 委托类型 事件名;
    //事件的使用
    //1.事件是作为 成员变量存在于类中
    //2.委托怎么用 事件就怎么用
    //事件相对于委托的区别：
    //1.不能在类外部 赋值
    //2.不能在类外部 调用

    //注意：它只能作为成员存在于类和接口以及结构体中
    class Test
    {
        //委托成员变量 用于存储函数
        public Action myFun;
        //事件成员变量 用于存储函数
        public event Action myEvent;

        public Test()
        {
            //事件的使用和委托一样 仅有些 细微区别
            myFun = TestFun;
            myFun += TestFun;
            myFun -= TestFun;
            myFun();
            myFun.Invoke();
            myFun = null;

            myEvent = TestFun;
            myEvent += TestFun;
            myEvent -= TestFun;
            myEvent();
            myEvent.Invoke();
            myEvent = null;
        }
        public void DoEvent()
        {
            if (myEvent != null)
            {
                myEvent();
            }
        }

        public void TestFun()
        {
            Console.WriteLine("123");
        }
    }
    #endregion

    #region 知识点三 为什么有事件
    //1.防止外部随意置空委托
    //2.防止外部随意调用委托
    //3.事件相当于对委托进行了封装 让其更加安全
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("事件");

            Test t = new Test();

            //委托可以在外部赋值
            t.myFun = null;
            t.myFun = TestFun;
            t.myFun = t.myFun + TestFun;
            t.myFun += TestFun;
            //事件不能在外部赋值 
            //t.myEvent = null;
            //但可以在外部追加或移除(+=或-=)
            t.myEvent += TestFun;
            t.myEvent -= TestFun;
            //t.myEvent = t.myEvent + TestFun;

            //委托可以在外部调用
            t.myFun();
            t.myFun.Invoke();
            //事件不能在外部调用
            //t.myEvent();
            //只能在类的内部去封装调用
            t.DoEvent();


            Action a = TestFun;
            //事件 是不能作为临时变量在函数中使用
            //event Action ae = TestFun;
        }
        static void TestFun()
        {

        }
    }
    //总结
    //事件和委托的区别
    //事件和委使用基本上是一模一样的
    //事件就是特殊的委托
    //主要区别
    //1.事件不能在外部使用赋值符号（=），只能追加或移除，委托都可以
    //2.事件不能在外部执行 委托都可以
    //3.事件 不能作为函数中的临时变量 委托可以
}
