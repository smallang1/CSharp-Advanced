namespace Lesson13_练习题
{
    #region 练习题
    //有一个热水器，包含一个加热器，一个报警器，一个显示器
    //给热水器通上电，当水温超过95度时
    //1.报警器会开始发出语音，告诉你水的温度
    //2.显示器也会改变水的温度，提示水已经烧开

    class Heater
    {
        private int value = 0; 
        public event Action<int> myEvent;
        public void AddHot()
        {
            int updeteIndex = 0;
            while (true)
            {
                if(updeteIndex % 9999999 == 0)
                {
                    ++value;
                    Console.WriteLine("加热到{0}度",value);

                    if(value >= 100)
                    {
                        break;
                    }

                    if(value >= 95)
                    {
                        if (myEvent != null)
                        {
                            myEvent(value);
                        }
                        //如果只想提醒一次 清空事件容器即可
                        myEvent = null;
                    }
                    updeteIndex = 0;
                }
                ++updeteIndex;
            }
        }
    }
    class Alarm
    {
        public void ShowInfo(int v)
        {
            Console.WriteLine("当前水温{0}度",v);
        }
    }

    class Display
    {
        public void ShowInfo(int v)
        {
            Console.WriteLine("水开了，当前水温{0}度", v);
        }
    }
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("事件练习题");

            Heater h = new Heater();
            Alarm a = new Alarm();
            Display d = new Display();
            h.myEvent += a.ShowInfo;
            h.myEvent += d.ShowInfo;

            h.AddHot();
        }
    }
}
