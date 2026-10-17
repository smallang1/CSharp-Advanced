using System.Collections;

namespace Lesson1_ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList");

            #region 练习题回顾
            //索引器练习题
            //自定义一个整型数组类，该类中有一个整型数组变量
            //为它封装增删改查方法
            #endregion

            #region ArrayList的本质
            //本质是一个object类型的数组
            //ArrayList类帮助实现了很多的方法，比如数组的增删改查
            #endregion

            #region 申明
            //需要引用命名空间using System.Collections;
            ArrayList array = new ArrayList();
            #endregion

            #region 增删改查

            //增
            array.Add(1);
            array.Add("123");
            array.Add(true);
            array.Add(12322);

            ArrayList array2 = new ArrayList();
            array2.Add(1);
            //批量增加
            array2.AddRange(array2);
            //插入元素
            array.Insert(0, 123);

            //删
            //移除指定元素 从头找 找到即删
            array.Remove(1);
            //移除指定位置的元素
            array.RemoveAt(0);
            //清空数组
            //array.Clear();

            //查
            //获取指定位置的元素
            Console.WriteLine(array[0]);

            //查看元素是否存在
            if (array.Contains(12322))
            {

                Console.WriteLine("存在");
            }

            //正向查找元素位置
            //找打返回值 是位置 找不到是-1
            int index = array.IndexOf(12322);
            Console.WriteLine(index);

            //反向查找元素位置
            //找到返回索引 找不到返回-1
            index = array.LastIndexOf(12322);
            Console.WriteLine(index);

            //改
            Console.WriteLine(array[0]);
            array[0] = "999";
            Console.WriteLine(array[0]);
            #endregion

            #region 遍历
            //长度
            Console.WriteLine(array.Count);
            //容量
            Console.WriteLine(array.Capacity);

            Console.WriteLine("*************");
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]);
            }

            //迭代器遍历
            foreach (object item in array)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 装箱拆箱
            //ArrayList本质上只一个可以自动扩容的object数组
            //由于万物之父来存储数据，自然存在装箱拆箱
            //当往其中进行值类型存储就叫做装箱，将值类型对象取出来转换使用时，就存在拆箱
            //所以ArrayList 尽量少用
            #endregion
        }
    }
}
