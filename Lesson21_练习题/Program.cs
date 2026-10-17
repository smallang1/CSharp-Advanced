using System.Reflection;

namespace Lesson21_练习题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("特性练习题");
            #region 练习题
            //为反射练习题中的Player对象
            //随便为其添加一个成员变量加一个自定义特性
            //同样实现反射练习题中的要求

            //但是当在设置加了自定义特性的成员变量时，在控制台中打印一句
            //非法操作，随意修改xxx成员

            Assembly assembly = Assembly.LoadFrom("C:\\Users\\90672\\source\\repos\\C#进阶\\类库测试\\bin\\Debug\\类库测试");
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i]);
            }
            //得Type
            Type playerType = assembly.GetType("MrZhang.Player");
            //实例化
             object playerObject = Activator.CreateInstance(playerType);
            Console.WriteLine(playerType);

            FieldInfo[] fields = playerType.GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i]);
            }

            //首先要得到自定义特性Type
            Type attribute = assembly.GetType("MrZhang.MyCustomAttribute");

            //赋值名字
            FieldInfo fieldStr = playerType.GetField("name");
            if (fieldStr.GetCustomAttribute(attribute) !=  null)
            {
                Console.WriteLine("非法操作，随意修改name成员");
            }
            else
            {
                //检测是否被自定义特性修饰 如果是不能修改  并提示
                fieldStr.SetValue(playerObject, "123123");
            }
            #endregion
        }
    }
}
