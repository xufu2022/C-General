﻿// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using ReflectionSample;

Console.Title = "Learning Reflection";

NetworkMonitor.BootstrapFromConfiguration();

Console.WriteLine("Monitoring network... something went wrong.");

NetworkMonitor.Warn();

Console.ReadLine();


var personType =typeof(Person);
var personConstructors=personType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic| BindingFlags.Public);

foreach (var personConstructor in personConstructors)
{
    Console.WriteLine(personConstructor);
}

var privatePersonConstructor= personType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
    null,new Type[]{typeof(string), typeof(int)}
    ,null);

var person1 = personConstructors[0].Invoke((null));
var person2 = personConstructors[1].Invoke(new object[]{"Kevin"});
var person3 = personConstructors[2].Invoke(new object[] { "Kevin", 40 });
var person40 = Activator.CreateInstance("ReflectionSample", "ReflectionSample.Person");
Type t1 = person40.GetType();
var person4 = Activator.CreateInstance("ReflectionSample", "ReflectionSample.Person").Unwrap();
Type t2 = person4.GetType();

var person5 = Activator.CreateInstance("ReflectionSample",
    "ReflectionSample.Person",
    true,
    BindingFlags.Instance | BindingFlags.Public,
    null,
    new object[] { "Kevin" },
    null,
    null);

var personTypeFromString = Type.GetType("ReflectionSample.Person");
var person6 = Activator.CreateInstance(personTypeFromString,
    new object[] { "Kevin" });

var person7 = Activator.CreateInstance("ReflectionSample",
    "ReflectionSample.Person",
    true,
    BindingFlags.Instance | BindingFlags.NonPublic,
    null,
    new object[] { "Kevin", 40 },
    null,
    null);

var assembly = Assembly.GetExecutingAssembly();
var person8 = assembly.CreateInstance("ReflectionSample.Person");

// create a new instance of a configured type
var actualTypeFromConfiguration = Type.GetType(GetTypeFromConfiguration());
var iTalkInstance = Activator.CreateInstance(actualTypeFromConfiguration) as ITalk;
iTalkInstance.Talk("Hello world!");

dynamic dynamicITalkInstance = Activator.CreateInstance(actualTypeFromConfiguration);
dynamicITalkInstance.Talk("Hello world!");

var personForManipulation = Activator.CreateInstance("ReflectionSample",
    "ReflectionSample.Person",
    true,
    BindingFlags.Instance | BindingFlags.NonPublic,
    null,
    new object[] { "Kevin", 40 },
    null,
    null)?.Unwrap();

var nameProperty = personForManipulation?.GetType().GetProperty("Name");
nameProperty?.SetValue(personForManipulation, "Sven");

var ageField = personForManipulation?.GetType().GetField("age");
ageField?.SetValue(personForManipulation, 36);

var privateField = personForManipulation?.GetType().GetField("_aPrivateField",
    BindingFlags.Instance | BindingFlags.NonPublic);
privateField?.SetValue(personForManipulation, "updated private field value");

personForManipulation?.GetType().InvokeMember("Name",
    BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
    null, personForManipulation, new[] { "Emma" });

Console.WriteLine(personForManipulation);

var talkMethod = personForManipulation?.GetType().GetMethod("Talk");
talkMethod?.Invoke(personForManipulation, new[] { "something to say" });

personForManipulation?.GetType().InvokeMember("Yell",
    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
    null, personForManipulation, new[] { "something to yell" });

Console.ReadLine();
static string GetTypeFromConfiguration()
{
    return "ReflectionSample.Person";
}

static void CodeFromSecondModule()
{
    //string name = "Kevin";
    //var stringType = name.GetType();
    //var stringType = typeof(string);
    //Console.WriteLine(stringType);

    var currentAssembly = Assembly.GetExecutingAssembly();
    var typesFromCurrentAssembly = currentAssembly.GetTypes();
    foreach (var type in typesFromCurrentAssembly)
    {
        Console.WriteLine(type.Name);
    }

    var oneTypeFromCurrentAssembly = currentAssembly.GetType("ReflectionSample.Person");

    foreach (var constructor in oneTypeFromCurrentAssembly.GetConstructors())
    {
        Console.WriteLine(constructor);
    }
    foreach (var method in oneTypeFromCurrentAssembly.GetMethods(
                 BindingFlags.Public | BindingFlags.NonPublic))
    {
        Console.WriteLine($"{method}, public: {method.IsPublic}");
    }

    foreach (var field in oneTypeFromCurrentAssembly.GetFields(
                 BindingFlags.Instance | BindingFlags.NonPublic))
    {
        Console.WriteLine(field);
    }


    //var externalAssembly = Assembly.Load("System.Text.Json");
    //var typesFromExternalAssembly = externalAssembly.GetTypes();
    //var oneTypeFromExternalAssembly = externalAssembly.GetType("System.Text.Json.JsonProperty");

    //var modulesFromExternalAssembly = externalAssembly.GetModules();
    //var oneModuleFromExternalAssembly = externalAssembly.GetModule("System.Text.Json.dll");

    //var typesFromModuleFromExternalAssembly = oneModuleFromExternalAssembly?.GetTypes();
    //var oneTypeFromModuleFromExternalAssembly = oneModuleFromExternalAssembly
    //    .GetType("System.Text.Json.JsonProperty");

}