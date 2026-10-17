namespace Lesson6_练习题
{
    #region 练习题一
    //用泛型实现一个单例模式基类
    class SingleBase<T> where T:new()
    {
        private static T instance = new T();

        public static T Instance
        {
            get
            {
                return instance;
            }
        }
    }
    class Test
    {
        private static Test instance = new Test();

        public int value = 10;
        private Test()
        {

        }
        public static Test Instance
        {
            get
            {
                return instance;
            }
        }
    }

    //存在问题：必须有一个公共无参的函数,外部不能去new，实例化
    class GameMgr : SingleBase<GameMgr>
    {
        public int value = 10;
    }
    #endregion

    #region 练习题二
    //利用泛型知识点，仿造ArrayList实现一个不确定数组类型的类
    //实现增删查改方法
    class ArrayList<T>
    {
        private T[] array;

        //当前存了多少数
        public int count;

        public ArrayList()
        {
            count = 0;
            //一开始的容量为16
            array = new T[16];
        }

        public void Add(T value)
        {
            //是否需要扩容
            if(count >= Capacity)
            {
                //搬家，每次扩容两倍
                T[] temp = new T[Capacity * 2];
                for(int i =0;i < Capacity; i++)
                {
                    temp[i] = array[i];
                }
                //地址重定向
                array = temp;
            }
            //不需要扩容
            array[count] = value;
            ++count;
        }

        public void Remove(T value)
        {
            //不是小于数组的容量，而是小于具体存了多少值
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                //不能用==判断 因为不是所有的类型都重载了运算符
                if (array[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }
            //只要不等于-1，就说明找到了 然后就移除
            if(index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            //索引合法不
            if(index < 0 || index >= Count)
            {
                Console.WriteLine("索引不合法");
                return;
            }

            //后面往前放
            for (; index < Count - 1; index++)
            {
                array[index] = array[index + 1];
            }
            //最后一个数移除 给默认值
            array[Count - 1] = default(T);
            --count;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return default(T);
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("索引不合法");
                    return;
                }
                array[index] = value;
            }
        }

        /// <summary>
        /// 获取容量
        /// </summary>
        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }

        /// <summary>
        /// 得到具体存了多少值
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

    }
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型约束练习题");

            Test.Instance.value = 20;

            GameMgr g = new GameMgr();

            GameMgr.Instance.value = 100;

            ArrayList<int> array = new ArrayList<int>();
            Console.WriteLine(array.count);
            Console.WriteLine(array.Capacity);
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Console.WriteLine(array.count);
            Console.WriteLine(array.Capacity);

            Console.WriteLine(array[1]);
            Console.WriteLine(array[-1]);
            Console.WriteLine(array[3]);

            array.RemoveAt(0);
            Console.WriteLine(array.count);
            for (int i = 0; i < array.count; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine(array[0]);
            array[0] = 99;
            Console.WriteLine(array[0]);
        }
    }
}
