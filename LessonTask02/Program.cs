using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LessonTask02
{
    //Выполните задачу 1 с сериализацией в формате Binary.
    class Program
    {
        static MyClass myClass = null;
        static MyClass myClass2 = null;
        static void Main(string[] args)
        {
            myClass = new MyClass("Hallo", "World", 12, 34);
            Console.WriteLine("#### До сериализации ####");
            myClass.GetFields();
            Console.WriteLine(new string('-',50));

            FileStream fs = new FileStream("Task02.dat", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, myClass);
            fs.Close();

            //Deserialisation
            fs = new FileStream("Task02.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            myClass2 = bf.Deserialize(fs) as MyClass;
            Console.WriteLine("#### После сериализации ####");
            myClass2.GetFields();
            Console.WriteLine(new string('-', 50));

        }
    }

    [Serializable]
    public class MyClass
    {
        private string strField1;
        private string strField2;
        private int intField3;
        private int intField4;

        public int IntField4
        {
            get { return intField4; }
            set { intField4 = value; }
        }
        public int IntField3
        {
            get { return intField3; }
            set { intField3 = value; }
        }
        public string StrField2
        {
            get { return strField2; }
            set { strField2 = value; }
        }
        public string StrField1
        {
            get { return strField1; }
            set { strField1 = value; }
        }

        public MyClass() { }
        public MyClass(string strField1, string strField2, int intField3, int intField4)
        {
            this.StrField1 = strField1;
            this.StrField2 = strField2;
            this.IntField3 = intField3;
            this.IntField4 = intField4;


        }
        public void GetFields()
        {
            Console.WriteLine($"field1= {strField1}\n" +
                $"field2= {strField2}\n" +
                $"field3 = {intField3}\n" +
                $"field4 = {intField4}");
        }
    }

}
