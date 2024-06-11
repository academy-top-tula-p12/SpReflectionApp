using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpReflectionApp
{
    public class Examples
    {
        public static void EmployeeReflectionType()
        {
            Employee employee = new Employee();

            Type emplType1 = typeof(Employee);
            Type emplType2 = employee.GetType();
            Type emplType3 = Type.GetType("Employee", false, true);

            //Console.WriteLine($"Name: {emplType1.Name}");
            //Console.WriteLine($"FullName: {emplType1.FullName}");
            //Console.WriteLine($"Namespace: {emplType1.Namespace}");
            //Console.WriteLine($"IsValueType: {emplType1.IsValueType}");
            //Console.WriteLine($"IsClass: {emplType1.IsClass}");
            //Console.WriteLine();

            //foreach (Type i in emplType1.GetInterfaces())
            //    Console.WriteLine(i.Name);
            //Console.WriteLine();

            //foreach (MemberInfo member in emplType1.GetMembers(
            //    BindingFlags.DeclaredOnly
            //    | BindingFlags.Public
            //    | BindingFlags.NonPublic
            //    | BindingFlags.Instance))
            //    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");


            //var methods = emplType1.GetMethods();
            //foreach (var m in methods)
            //{
            //    string mStr = $"{m.ReturnType} {m.Name} ";
            //    mStr += (m.IsStatic) ? "static " : "non static ";
            //    mStr += (m.IsVirtual) ? "virtual " : "non virtual ";
            //    Console.WriteLine(mStr);
            //}
        }
        public static void AccountMethodsParameters()
        {
            Type accType = typeof(Account);

            foreach (MethodInfo method in accType.GetMethods())
            {
                Console.WriteLine($"{method.ReturnType} {method.Name}");

                ParameterInfo[] parameters = method.GetParameters();
                foreach (ParameterInfo param in parameters)
                {
                    string paramStr = $"\t{param.Position} - {param.ParameterType.Name} {param.Name} ";
                    if (param.HasDefaultValue)
                        paramStr += $" default = {param.DefaultValue}";

                    Console.WriteLine(paramStr);
                }
                Console.WriteLine();
            }
        }
        public static void AccountConstructorsMethodsInvoke()
        {
            Type accType = typeof(Account);

            ConstructorInfo[] ctors = accType.GetConstructors();
            ConstructorInfo? ctorDefault = null;

            foreach (ConstructorInfo ctor in ctors)
            {
                string modis = "";
                if (ctor.IsPublic) modis += "public ";
                if (ctor.IsAssembly) modis += "internal ";
                if (ctor.IsPrivate) modis += "private ";
                if (ctor.IsFamily) modis += "protected ";
                if (ctor.IsFamilyAndAssembly) modis += "private protected ";
                if (ctor.IsFamilyOrAssembly) modis += "protected internal ";

                Console.WriteLine($"{modis} {accType.Name}");

                ParameterInfo[] pars = ctor.GetParameters();
                if (pars.Length == 0)
                    ctorDefault = ctor;

                foreach (ParameterInfo par in pars)
                {
                    Console.WriteLine($"\t{par.Position} {par.ParameterType.Name} {par.Name}");
                }
                Console.WriteLine();
            }

            var obj = ctorDefault?.Invoke(null);

            MethodInfo? addMethod = accType.GetMethod("AddToBalance");

            addMethod?.Invoke(obj, new object[] { 1000m, 1.1 });
        }  
        public static void AccountFieldsProperties()
        {
            Type accType = typeof(Account);
            FieldInfo[] fields = accType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
                Console.WriteLine($"{field.FieldType.Name} {field.Name}");

            var ctor = accType.GetConstructor(new Type[] { });
            var obj = ctor?.Invoke(null);

            var balance = accType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)[1];
            balance.SetValue(obj, 1000m);

            Console.WriteLine(((Account)obj).Balance);

            PropertyInfo[] props = accType.GetProperties();
            foreach (PropertyInfo prop in props)
                Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");

            var name = accType.GetProperties()[0];
            Console.WriteLine(name.GetValue(obj));
            name.SetValue(obj, "Privilegy");
            Console.WriteLine(name.GetValue(obj));
        }
    }
}
