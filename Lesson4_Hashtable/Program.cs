using System.Collections;

namespace Lesson4_Hashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hashtable");

            #region 知识点一 Hashtable的本质
            //Hashtable（又称散列表）是基于键的哈希代码组织起来的  键/值对
            //主要作用是提高数据查询的效率
            //使用键来访问集合中的元素
            #endregion

            #region 知识点二 申明
            //需要引用命名空间 System.Collections
            Hashtable hashtable = new Hashtable();
            #endregion

            #region 知识点三 增删改查
            //增
            hashtable.Add(1, "123");
            hashtable.Add("123", 1);
            hashtable.Add(true, false);
            hashtable.Add(false, false);
            //注意不能出现相同键
            //hashtable.Add(1, "456");


            //删
            //1.只能通过键去删除
            hashtable.Remove(1);
            //2.删除不存在的键 没反应
            hashtable.Remove(2);
            //3.或者直接清空
            hashtable.Clear();
            hashtable.Add(1, "123");
            hashtable.Add(2, "123");
            hashtable.Add(3, "789");
            hashtable.Add("123123", 123);


            //查
            //1.通过键查看值，找不到返回空
            Console.WriteLine(hashtable[1]);
            Console.WriteLine(hashtable["123123"]);
            Console.WriteLine(hashtable[8]);
            //2.查看是否存在
            //根据键检测
            if (hashtable.ContainsKey(2))
            {
                Console.WriteLine("存在");
            }
            //根据值检测
            if (hashtable.ContainsValue("123"))
            {
                Console.WriteLine("存在");
            }


            //改
            //只能改 键对应的值内容 无法修改键
            hashtable[1] = 666;
            Console.WriteLine(hashtable[1]);
            #endregion

            #region 知识点四 遍历
            //得到键值对 对数
            Console.WriteLine(hashtable.Count);

            //1.遍历所有键
            //1.遍历所有键
            foreach (object item in hashtable.Keys)
            {
                Console.WriteLine("键：" +item);
                Console.WriteLine("值：" +hashtable[item]);

            }

            //2.遍历所有值
            foreach (object item in hashtable.Values)
            {
                Console.WriteLine("值："+ item);
            }

            //3.遍历所有键值对
            foreach (DictionaryEntry item in hashtable)
            {
                Console.WriteLine("键：" + item.Key + " 值：" + item.Value);
            }

            //4.迭代器遍历
            IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
            bool flag = myEnumerator.MoveNext();
            while (flag)
            {
                Console.WriteLine("键：" + myEnumerator.Key + " 值：" + myEnumerator.Value);
                flag = myEnumerator.MoveNext();
            }
            #endregion

            #region 知识点五 装箱拆箱
            #endregion
        }
    }
}
