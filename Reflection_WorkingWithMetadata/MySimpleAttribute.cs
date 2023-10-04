using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_WorkingWithMetadata
{
    //В стандартній ситуації, створений атрибут, можна використовувати для всього
    //Для методів, класів, властивостей і т.д.
    //Проте його використання можна обмежити, використовуючи спеціальний атрибут,
    //при створенні атрибуту. Тавтологія виходить)
    [AttributeUsage(AttributeTargets.Property)]
    internal class MySimpleAttribute : Attribute
    {
        public int Number{ get; set; }
    }
}
