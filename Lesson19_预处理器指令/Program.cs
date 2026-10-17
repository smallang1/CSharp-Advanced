#define Unity5
#define Unity4
//#define Unity2017
#define Unity2019

//取消定义的符号
#undef Unity4

namespace Lesson19_预处理器指令
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("预处理器指令");

            #region 知识点一 什么是编译器
            //编译器是一种翻译软件
            //它用于将源语言程序翻译为目标语言程序

            //源语言程序：某种程序设计语言写成的，比如C#、C、C++、java等语言写的程序
            //目标语言程序：二进制数表示的伪机器代码写的程序
            #endregion

            #region 知识点二 什么是预处理器指令
            //预处理器指令 指导编译器 在实际编译开始之前对信息进行预处理
            //预处理指令 都是#开始
            //预处理指令不是语句，所以它们不以; 结束
            //目前我们经常用到的 折叠代码块 就是预处理器指令
            #endregion

            #region 知识点三 常见的预处理器指令
            //#define
            //定义一个符号，类似一个没有值的变量
            //#under
            //取消define定义的符号，让其失效
            //两者都是写在脚本文件最前面
            //一般配合 if指令使用 或配合特性

            //#if
            //#elif
            //#else
            //#endif
            //和if语句规则一样，一般配合#define定义的符号使用
            //用于告诉编译器进行编译代码的流程控制

            //如果发现有Unity4这个符号 那么其中包含的代码 就会被编译器翻译
            //可以通过 逻辑或 和逻辑与 进行多种符号的组合判断
#if Unity4
            Console.WriteLine("版本为Unity4");

#elif Unity2017
            Console.WriteLine("版本为Unity2017");

//#warning 版本不合法
#error 这个版本不能执行

#else
            Console.WriteLine("其他版本");
            #endif


            //#warning
            //#error
            //告诉编译器 是警告还是报错误
            //一般还是配合if使用
            #endregion
        }
    }
}
