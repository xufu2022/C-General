using ReflectionMagic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericReflection
{
    public class ReflectionMagicSample
    {
       public static void Process()
        {
            var person = new Person("Kevin");
            var privateField = person.GetType().GetField(
                "_aPrivateField",
                BindingFlags.Instance | BindingFlags.NonPublic);

            privateField?.SetValue(person, "New private field value");

            person.AsDynamic()._aPrivateField = "Updated value via ReflectionMagic";

            Console.Write("end of ReflectionMagicSample");
        }
    }
}
