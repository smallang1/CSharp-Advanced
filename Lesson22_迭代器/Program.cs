using System.Collections;

namespace Lesson22_迭代器
{
    #region 知识点一 迭代器是什么
    //迭代器（iterator）有时又称光标（cursor）
    //是程序设计的软件设计模式
    //迭代器模式提供了一个方法顺序访问一个聚合对象中的各个元素
    //而又不暴露其内部的标识

    //在表面效果上看
    //是可以在容器对象（例如链表或数组）上遍历访问的接口
    //设计人员无需关心容器对象的内存分配的实现细节
    //可以用foreach遍历的类，都是实现了迭代器的
    #endregion

    #region 知识点二 标准迭代器的实现方法
    //关键接口：IEnumerator，IEnumberable
    //命名空间：using System.Collections;
    //可以通过同时继承IEnumberable和IEnumberator实现其中的方法

    class CustomList :IEnumerable,IEnumerator
    {
        public int[] list;
        //从-1开始的光标 用于表示 数据得到了哪个位置
        public int position = -1;

        public CustomList()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        
        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }

        #endregion


        public object Current
        {
            get
            {
                return list[position];
            }
        }
        public bool MoveNext()
        {
            //移动光标
            ++position;
            //是否溢出  溢出就不合法
            return position < list.Length;
        }


        //reset 重置光标位置 一般写在 IEnumerator对象函数中
        //用于第一次重置光标位置
        public void Reset()
        {
            position = -1;
        }



    }
    #endregion

    #region 知识点三 用yield return 语法糖实现迭代器
    //yield return 是C#提供给我们的语法糖
    //所谓语法糖，也称糖衣语法
    //主要作用就是将复杂逻辑简单化，可以增加程序的可读性
    //从而减少程序代码出错的机会

    //关键接口：IEnumerable
    //命名空间：using System.Collections;
    //让想要通过foreach遍历的自定义类实现接口中的方法GetEnumerator即可
    class CustomList2 : IEnumerable
    {
        private int[] list;
        public CustomList2()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                //yield关键字 配合迭代器使用
                //可以理解为 暂时返回 保留当前状态
                //一会还会再回来
                //C#语法糖
                yield return list[i];
            }
            //或
            //yield return list[0];
            //yield return list[1];
            //yield return list[2];
            //yield return list[3];
            //yield return list[4];
            //yield return list[5];
            //yield return list[6];
            //yield return list[7];

        }
    }
    #endregion

    #region 知识点四 用yield return 语法糖为泛型类实现迭代器
    class CustomList<T> : IEnumerable
    {
        private T[] array;

        public CustomList(params T[] array)
        {
            this.array = array;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("迭代器");
            CustomList list = new CustomList();


            //foreach本质
            //1.先获取in后面这个对象的 IEnumerable
            //会调用对象其中的GetEnumerator方法 来获取
            //2.执行得到这个IEnumerator对象中的 MoveNext方法
            //3.只要MoveNext方法的返回值为true 就会去得到Current
            //  然后赋值给 item
            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}

            CustomList<string> List2 = new CustomList<string>("123","3321","3233");
            foreach (string item in List2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
