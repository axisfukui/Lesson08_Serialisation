using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LessonTask01
{
//Создайте класс MyClass.В данном классе создайте 4 приватных поля – 2 строковых и 2 целочисленных.В теле метода Main создайте экземпляр класса MyClass и проинициализируйте все поля данного класса.Выполните сериализацию экземпляра MyClass в XML файл и десериализацию из XML файла в новый экземпляр MyClass.Выведите на экран значение полей нового экземпляра MyClass.
//При создании MyClass примите во внимание, что сериализоваться должны только значения одного строкового поля и одного целочисленного.

    class Program
    {
        readonly static XmlSerializer xmlSerializer = new XmlSerializer(typeof(MyClass));
        static MyClass myClass;
        static MyClass myClass2;
        static void Main(string[] args)
        {
            myClass = new MyClass("test", "test2", 1, 2);
            myClass2 = null;
            Console.WriteLine("Объект для сериализации");
            myClass.GetFields();
            Console.WriteLine(new string('-',50));
            try
            {
                FileStream fs = new FileStream("MyClass.xml", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                xmlSerializer.Serialize(fs, myClass);
                fs.Close();

                fs = new FileStream("MyClass.xml", FileMode.Open, FileAccess.Read);
                myClass2 = xmlSerializer.Deserialize(fs) as MyClass;

                Console.WriteLine("Объект после сериализации");
                myClass2.GetFields();
                Console.WriteLine(new string('-', 50));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    [XmlRoot]
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
        [XmlIgnore]
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
        [XmlIgnore]
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
