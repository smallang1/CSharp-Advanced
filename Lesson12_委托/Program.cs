namespace Lesson12_委托
{
    #region 知识点一 委托是什么
    //委托是 函数的容器
    //可以理解为表示（方法）的变量类型
    //用来 存储、传递函数
    //委托的本质是一个类，用来定义函数（方法）的类型（返回值和参数的类型）
    //不同的是 函数必须对应和各自"格式"一致的委托
    #endregion

    #region 知识点二 基本语法
    //关键字: delegate
    //语法：访问修饰符 delegate 返回值 委托名（参数列表）:

    //写在哪
    //可以申明在namespace和class语句块中
    //更多的写在namespace中

    //简单来记，委托语法 就是 函数申明语法前面加一个delegate关键字
    #endregion

    #region 知识点三 定义自定义委托
    //访问修饰符默认不写 为public 在别的命名空间中也能使用
    //private 其他命名空间就不能使用了
    //一般为public

    //申明了一个用来存储无参无返回值函数的容器
    //在这只是定义了规则 但并没有使用
    delegate void MyFun();

    //委托规则的申明 是不能够重名的（同一语句块中）
    //表示 用来装载或传递 返回值为int 有一个int参数的函数的 委托 容器规则
    public delegate int MyFun2(int a);

    //委托支持泛型 可以让返回值和参数可变 更方便使用
    delegate T MyFun3<T>(T t);

    #endregion

    #region 知识点四 使用定义好的委托
    //委托变量是函数的容器

    //委托常用在
    //1.作为类的成员
    //2.作为函数的参数
    class Test
    {
        public MyFun fun;
        public MyFun2 fun2;

        public Action action;

        public void TestFun(MyFun fun,MyFun2 fun2)
        {
            //好处：可以先处理别的逻辑 处理完之后 再执行传入的函数
            int i = 1;
            i *= 2;
            i += 2;

            //fun();
            //fun2(i);
            //this.fun = fun;
            //this.fun2 = fun2;
        }

        #region 增
        public void AddFun(MyFun fun,MyFun2 fun2)
        {
            this.fun += fun;
            this.fun2 += fun2;
        }
        #endregion

        #region 删
        public void RemoveFun(MyFun fun,MyFun2 fun2)
        {
            //this.fun = this.fun - fun;
            this.fun -= fun;
            this.fun2 -= fun2;
        }
        #endregion
    }
    #endregion

    #region 知识点五 委托变量可以存储多个函数(多播委托)

    #endregion

   

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("委托");
            //专门用来装载函数的容器
            //第一种申明 调用方式
            MyFun f = new MyFun(Fun);
            f.Invoke();

            //第二种申明 调用方式
            MyFun f2 = Fun;
            f2();

            MyFun2 f3 = Fun2;
            Console.WriteLine(f3(666));                 //第一种调用方式

            MyFun2 f4 = new MyFun2(Fun2);
            Console.WriteLine(f3.Invoke(899));          //第二种调用方式


            Test t = new Test();
            t.TestFun(Fun, Fun2);


            Console.WriteLine("*******************");
            //如何用委托存储多个函数
            //MyFun ff = Fun;
            MyFun ff = null;
            //ff = ff + Fun;
            ff += Fun;
            ff += Fun3;
            ff();
            //从容器中移除指定的函数
            ff -= Fun;
            //多减 不会报错 只是不处理而已
            ff -= Fun;
            ff();
            //清空容器
            ff = null;
            if(ff!= null)
            {
                ff();
            }

            //t.AddFun(Fun, Fun2);
            //t.fun();
            //t.fun2(50);

            #region 知识点六 系统定义好的委托
            //使用系统自带委托 需要引用命名空间using System;
            //无参无返回值
            Action action = Fun;
            action += Fun3;
            action();


            //可以指定返回值类型的 泛型委托
            Func<string> funString = Fun4;
            Func<int> funInt = Fun5;

            //可以传n个参数的 系统提供的1到16个参数的委托 可以直接使用
            Action<int, string> ac = Fun6;

            //可以传n个参数 并且有返回值的
            Func<int, int> fun2 = Fun2;
            #endregion
        }

        static void Fun()
        {
            Console.WriteLine("张三做什么");
        }

        static void Fun3()
        {
            Console.WriteLine("李四做什么");
        }

        static string Fun4()
        {
            return "";
        }

        static int Fun5()
        {
            return 1;
        }

        static void Fun6(int i,string s)
        {

        }
        static int Fun2(int value)
        {
            return value;
        }
    }
}
