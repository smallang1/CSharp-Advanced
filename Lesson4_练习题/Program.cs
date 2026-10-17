using System.Collections;

namespace Lesson4_练习题
{
    #region 练习题一
    //请描述Hashtable的存储规则

    //一个键值对形式存储的容器
    #endregion

    #region 练习题二
    //制作一个怪物管理器，提供创建怪物
    //移除怪物的方法，每个怪物都有自己的唯一ID

    /// <summary>
    /// 怪物管理器 因为管理器都是唯一的 所以用单例模式
    /// </summary>
    class MonsterMgr
    {
        private Hashtable monstersTable = new Hashtable();
        private static MonsterMgr instance = new MonsterMgr();

        private MonsterMgr()
        {

        }
        public static MonsterMgr Instance
        {
            get
            {
                return instance;
            }
        }

        private int monsterId = 0;
        public void AddMonster()
        {
            Monster monster = new Monster(monsterId);
            Console.WriteLine("创建了id为{0}怪物", monsterId);
            ++monsterId;

            //hashtable的键是不能重复的 所以要用唯一ID
            monstersTable.Add(monster.id, monster);
        }
        public void RemoveMonster(int monsterId)
        {
            if(monstersTable.ContainsKey(monsterId))
            {
                (monstersTable[monsterId] as Monster).Dead();
                monstersTable.Remove(monsterId);
            }
        }
    }

    class Monster
    {
        public int id;
        public Monster(int id)
        {
            this.id = id;
        }
        public void Dead()
        {
            Console.WriteLine("怪物{0}死亡", id);
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hashtable练习题");

            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();
            MonsterMgr.Instance.AddMonster();

            MonsterMgr.Instance.RemoveMonster(0);
            MonsterMgr.Instance.RemoveMonster(3);

        }
    }
}
