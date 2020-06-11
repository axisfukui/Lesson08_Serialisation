using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LessonTask03
{
    //Создайте структуру Triangle реализующую интерфейс IDeserializationCallback.В теле структуры создайте:
    //•	три public поля – обозначающие стороны треугольника;
    //•	private поле, обозначающие периметр треугольника(значение поля должно заполняться во время инициализации полей и не сериализовываться);
    //•	private метод, выполняющий вычисление периметра.
    //Реализуйте логику работы интерфейса IDeserializationCallback с тем, чтобы при десериализации экземпляров Triangle происходило вычисление значения поя периметра.
    //Сериализуйте экземпляр и десериализуйте.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("До Сериализации");
            Triangle testTriangle = new Triangle() { a = 24, b = 13, c = 34 };

            Console.WriteLine($"A= {testTriangle.a} | B= {testTriangle.b} |C= {testTriangle.c} \n" +
                $"Perimetr = {testTriangle.Perimeter}");
            Console.WriteLine(new string('-', 50));

            //serialisation
            FileStream fs = new FileStream("MyTriangle.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, testTriangle);
            fs.Close();

            fs = new FileStream("MyTriangle.dat", FileMode.Open, FileAccess.Read);
            Triangle newTriangle = (Triangle)bf.Deserialize(fs);
            Console.WriteLine("После Сериализации");
            Console.WriteLine($"A= {newTriangle.a} | B= {newTriangle.b} |C= {newTriangle.c} \n" +
                $"Perimetr = {newTriangle.Perimeter}");
            Console.WriteLine(new string('-', 50));

        }
    }

    [Serializable]
    struct Triangle : IDeserializationCallback
    {
        public int a;
        public int b;
        public int c;
        [NonSerialized]
        private int perimeter;

        public int Perimeter => perimeter;
        public void OnDeserialization(object sender)
        {
            perimeter = a + b + c;
        }
    }
}
