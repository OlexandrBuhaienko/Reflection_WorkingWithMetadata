using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_WorkingWithMetadata
{
    internal class Student
    {
        private int _temp = 7;
        public string Name { get; set; }
        //Не можна змінювати значення атрибуту під час виконання програми,
        //потрібно додавати ці значення як константи, які в принципі не можуть змінюватись,
        //Як правило такий спосіб ініціалізації значень атрибутів використовується для
        //значень, які не можуть змінюватись під час виконання програми.
        //Наприклад - Connection String
        [MySimple (Number = 5)]
        public string Age { get; set; }
    }
}
