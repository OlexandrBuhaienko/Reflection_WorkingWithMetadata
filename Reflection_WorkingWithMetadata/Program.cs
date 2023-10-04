using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Reflection_WorkingWithMetadata
{
    internal class Program
    {
        // Отримання опису типу по строковому іменуванню
        //Метод, який отримує метадані про члени класу які є нестатичними та приватними,
        // Через механізм рефлексії, та виводить їх назви в консоль
        public static void GetMembersInfo(string stringType)
        {
            Type type = Type.GetType(stringType);
            var members = type.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MemberInfo memberInfo in members)
            {
                Console.WriteLine(memberInfo.Name);
            }
            Console.ReadLine();
        }
        // Отримання опису типу за екземпляром класу
        // Метод який отримує всі приватні нестатичні поля класу, потім серед цих полів 
        // шукає поле з назвою _temp. А потім його змінює, паралельно виводить значення 
        // цього поля в консоль до його зміни, методом рефлексії, та після.
        public static void ShowValuesOfTypeFields()
        {
            Student student = new Student();

            Type type = student.GetType();

            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo  fieldInfo in fields)
            {
                if(fieldInfo.Name == "_temp")
                {
                    var value = fieldInfo.GetValue(student);
                    Console.WriteLine($"Before changing value via reflection : {value}");

                    fieldInfo.SetValue(student, 15);

                    value = fieldInfo.GetValue(student);
                    Console.WriteLine($"After changing value via reflection : {value}");
                }
            }
            Console.ReadLine();
        }
        // Метод, який створює екземпляр типу , шляхом виклику конструктора, отриманого типу
        // отримує опис типу, за назвою типу та ключовим словом typeof
        // Викликає конструктор, за допомогою класу ConstructorInfo, та методу Invoke()
        // Параметром в конструктор приймає масив параметрів, необхідних для конструктора типу
        // Але оскільки в нашому класі Student немає конструктора з параметрами, то передається
        // Порожній масив, так само як у вмклику конструктора, за допомогою методу Invoke();
        public static void CreateNewInstanceOfType()
        {
            Type type = typeof(Student);
            ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { });
            object student = constructorInfo.Invoke(new object[] { });
        }
        // Цей метод використовуючи рефлексію, звертається до всіх властивостей типу Student
        // з кожної властивості в типі, він пробує отримати кастомний атрибут, який 
        // розробник міг додати, тому метод GetCustommAttributes повертає перелік властивостей  
        // до яких застосували кастомні атрибути, у вигляді масиву, 
        // тип атрибутів в цьому масиві MySimpleAttribute. Потім якщо довжина цього масиву
        // більша за 0, то виводить назву властивості, до якої застосували MySimpleAttribute 
        public static void WorkWithAttributes()
        {
            Student student = new Student();
            Type type = student.GetType();
            var properties = type.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                // Беремо перший елемент масиву, приводимо його до типу атрибуту, яке ми шукали
                // Та виводимо його значення разом з назвою властивості в консоль
                var attributes = propertyInfo.GetCustomAttributes(typeof(MySimpleAttribute), 
                false);
                // Виводимо ми не тільки назву властивості,
                // до якої ми додали атрибут MySimpleAttribute,
                // а також і значення, яке ми вказали,
                // коли додавали цей атрибут до властивості,
                // в нашому випадку - це Number.
                // І значення його ми вказали - 5
                if(attributes.Length > 0)
                {
                    var attribute = (MySimpleAttribute)attributes[0];

                    Console.WriteLine($"Property name : {propertyInfo.Name}," +
                        $" attribute value : {attribute.Number}");
                }
            }
        }
        public static void Main(string [] args)
        {
            string stringType = "Reflection_WorkingWithMetadata.Student";
            GetMembersInfo(stringType);
            ShowValuesOfTypeFields();
            WorkWithAttributes();
        }
    }
}