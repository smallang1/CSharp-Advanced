using System.Collections.Generic;

namespace Lesson8_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary");

            #region 知识点一 Dictionary的本质
            //可以将Dictionary理解为 拥有泛型的Hashtable
            //它也是基于键的哈希代码组织起来的 键/值对
            //键值对类型从Hashtable的object变为了可以自己指定的泛型
            #endregion

            #region 知识点二 申明
            //需要引用命名空间 using System.Collections.Generic
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            #endregion

            #region 知识点三

            #region 增
            //注意：不能存在相同的键
            dictionary.Add(1,"123");
            dictionary.Add(2,"222");
            dictionary.Add(3,"222");
            #endregion

            #region 删
            //1.只能通过键去删除
            // 删除不存在的键 没反应
            dictionary.Remove(1);


            //2.清空
            dictionary.Clear();
            dictionary.Add(1, "123");
            dictionary.Add(2, "222");
            dictionary.Add(3, "222");
            #endregion

            #region 查
            //1.通过键查看值
            //  找不到直接报错
            Console.WriteLine(dictionary[1]);
            //Console.WriteLine(dictionary[5]);
            Console.WriteLine(dictionary[2]);

            //2.查看是否存在
            //根据键检测
            if (dictionary.ContainsKey(1))
            {
                Console.WriteLine("存在");
            }
            //根据值检测
            if (dictionary.ContainsValue("123"))
            {
                Console.WriteLine("存在");
            }

            #endregion

            #region 改
            Console.WriteLine(dictionary[1]);
            dictionary[1] = "666";
            Console.WriteLine(dictionary[1]);
            #endregion

            #endregion

            #region 知识点四 遍历
            Console.WriteLine("********************");
            Console.WriteLine(dictionary.Count);
            //1.遍历所有键
            foreach (int item in dictionary.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(dictionary[item]);
            }
            //2.遍历所有值
            Console.WriteLine("********************");
            foreach (string item in dictionary.Values)
            {
                Console.WriteLine(item);
            }
            //3.键值对一起遍历
            Console.WriteLine("********************");
            foreach (KeyValuePair<int,string> item in dictionary)
            {
                Console.WriteLine("键" + item.Key + "值" + item.Value);
            }
            #endregion
        }
    }
}
