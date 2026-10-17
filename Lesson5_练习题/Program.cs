namespace Lesson5_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型练习题");
            #region 练习题
            //定义一个泛型方法，方法内判断该类型为何类型，并返回类型的名称与占有的字节数
            //如果时int，则返回“整型，4字节”
            //只考虑以下类型
            //int：整型
            //char：字符型
            //float：浮点型
            //string：字符串型
            //如果是其他类型，则返回 其他类型
            //可以通过typeof(类型) == typeof(类型) 方法进行类型判断

            Console.WriteLine(Fun<int>());
            Console.WriteLine(Fun<char>());
            Console.WriteLine(Fun<float>());
            Console.WriteLine(Fun<string>());
            Console.WriteLine(Fun<bool>());

            #endregion
        }
        static string Fun<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return string.Format("{0}，{1}字节", "整型",sizeof(int));
            }
            else if (typeof(T) == typeof(char))
            {
                return string.Format("{0}，{1}字节", "字符", sizeof(char));
            }
            else if (typeof(T) == typeof(float))
            {
                return string.Format("{0}，{1}字节", "单精度", sizeof(float));
            }
            else if (typeof(T) == typeof(string))
            {
                return string.Format("{0}，{1}字节", "字符串", "？");
            }

            return "其他类型";
        }
    }
}
