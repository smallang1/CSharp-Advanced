using System.Collections.Generic;
using System.Globalization;
using System.Threading.Channels;

namespace Lesson16_练习题
{
    #region 练习题一
    //写一个怪物类，创建10个怪物将其添加到List中
    //对List列表进行排序，根据用户输入数字进行排序
    //1.攻击排序
    //2.防御排序
    //3.血量排序
    //4.反转

    class Monster
    {
        public static int SortType = 1;

        public int hp;
        public int atk;
        public int def;

        public Monster(int hp,int atk,int def)
        {
            this.hp = hp;
            this.atk = atk;
            this.def = def;
        }
        public override string ToString()
        {
            return string.Format("怪物信息-血量{0}攻击力{1}防御力{2}", this.hp, this.atk, this.def);
        }
    }
    #endregion

    #region 练习题二
    //写一个物品类（类型，名字，品质），创建10个物品
    //添加到List中
    //同时使用类型、品质、名字长度进行比较
    //排序的权重：类型>品质>名字长度
    class Item
    {
        public int type;
        public string name;
        public int quality;

        public Item(int type,string name,int quality)
        {
            this.type = type;
            this.name = name;
            this.quality = quality;
        }
        public override string ToString()
        {
            return string.Format("道具信息-类型{0} 名字{1} 品质{2}",type,name,quality);
        }
    }
    #endregion

    #region 练习题三
    //linq SQL

    //请尝试利用List排序方式对Dictionary中的内容排序
    //提示：得到dictionary的所有键值对信息存入List中
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List练习题");

            /*List<Monster> monsters = new List<Monster>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                monsters.Add(new Monster(r.Next(100,201),r.Next(5,21),r.Next(2,10)));
                Console.WriteLine(monsters[i]);
            }

            Console.WriteLine("*******************");
            try
            {
                Console.WriteLine("请输入1-4进行排序");
                Console.WriteLine("1:按攻击力升序排序");
                Console.WriteLine("2:按防御力升序排序");
                Console.WriteLine("3:按血量升序排序");
                Console.WriteLine("4:反转");
                Monster.SortType = int.Parse(Console.ReadLine());
                if(Monster.SortType == 4)
                {
                    monsters.Reverse();
                }
                else
                {
                    monsters.Sort(SortFun);
                }

                    //int inputIndex = int.Parse(Console.ReadLine());
                    //switch (inputIndex)
                    //{
                    //    case 1:
                    //        monsters.Sort((a, b) =>
                    //        {
                    //            return a.atk > b.atk ? 1 : -1;
                    //        });
                    //        break;
                    //    case 2:
                    //        monsters.Sort((a, b) =>
                    //        {
                    //            return a.def > b.def ? 1 : -1;
                    //        });
                    //        break;
                    //    case 3:
                    //        monsters.Sort((a, b) =>
                    //        {
                    //            return a.hp > b.hp ? 1 : -1;
                    //        });
                    //        break;
                    //    case 4:
                    //        //反转api
                    //        monsters.Reverse();
                    //        break;
                    //}
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(monsters[i]);
                    }
            }
            catch
            {
                Console.WriteLine("请输入数字");
            }*/


            List<Item> itemList = new List<Item>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                itemList.Add(new Item(r.Next(1,6),"Item" + r.Next(1,201),r.Next(1,6)));
                Console.WriteLine(itemList[i]);
            }
            itemList.Sort((a, b) =>
            {
                //类型不同 按类型比
                if (a.type != b.type)
                {
                    return a.type > b.type ? -1 : 1;
                }
                //按品质比
                else if(a.quality != b.quality)
                {
                    return a.quality > b.quality ? -1 : 1;
                }
                //按长度比
                else
                {
                    return a.name.Length > b.name.Length ? -1 : 1;
                }
            });

            Console.WriteLine("*************************");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(itemList[i]);
            }


            //练习题三
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(2,"123123");
            dic.Add(6,"123123");
            dic.Add(1,"123123");
            dic.Add(4,"123123");
            dic.Add(3,"123123");
            dic.Add(5,"123123");

            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();


            foreach (KeyValuePair<int,string> item in dic)
            {
                list.Add(item);
                Console.WriteLine(item.Key + "_" +item.Value);
            }
            list.Sort((a, b) =>
            {
                return a.Key > b.Key ? 1 : -1;
            });

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Key + "_" + list[i].Value);
            }
        }
        static int SortFun(Monster m1,Monster m2)
        {
            switch (Monster.SortType)
            {
                case 1:
                    return m1.atk > m2.atk ? 1 : -1;
                case 2:
                    return m1.def > m2.def ? 1 : -1;
                case 3:
                    return m1.hp > m2.hp ? 1 : -1;
            }
            return 0;
        }
    }
}
