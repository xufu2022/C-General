// See https://aka.ms/new-console-template for more information

using GenericReflection;

Console.Title = "Learning Reflection";

var iocContainer = new IoCContainer();
iocContainer.Register<IWaterService, TapWaterService>();
var waterService = iocContainer.Resolve<IWaterService>();

//iocContainer.Register<IBeanService<Catimor>, ArabicaBeanService<Catimor>>();
//iocContainer.Register<IBeanService<>, ArabicaBeanService<>>();
//iocContainer.Register<typeof(IBeanService<>), typeof(ArabicaBeanService<>)>();
iocContainer.Register(typeof(IBeanService<>), typeof(ArabicaBeanService<>));

iocContainer.Register<ICoffeeService, CoffeeService>();
var coffeeService = iocContainer.Resolve<ICoffeeService>();

Console.ReadLine();

static void GenericStepThrough()
{
    var myList = new List<Person>();
    Console.WriteLine(myList.GetType());

    var myDictionary = new Dictionary<string, int>();
    Console.WriteLine(myDictionary.GetType());

    var dictionaryType = myDictionary.GetType();
    foreach (var genericTypeArgument in dictionaryType.GenericTypeArguments)
    {
        Console.WriteLine(genericTypeArgument);
    }
    foreach (var genericArgument in dictionaryType.GetGenericArguments())
    {
        Console.WriteLine(genericArgument);
    }

    var openDictionaryType = typeof(Dictionary<,>);
    foreach (var genericTypeArgument in openDictionaryType.GenericTypeArguments)
    {
        Console.WriteLine(genericTypeArgument);
    }
    foreach (var genericArgument in openDictionaryType.GetGenericArguments())
    {
        Console.WriteLine(genericArgument);
    }

    var createdInstance = Activator.CreateInstance(typeof(List<Person>));
    Console.WriteLine(createdInstance.GetType());

    var openResultType = typeof(Result<>);
    var closedResultType = openResultType.MakeGenericType(typeof(Person));
    var createdResult = Activator.CreateInstance(closedResultType);
    Console.WriteLine(createdResult.GetType());

    var openResultType2 = Type.GetType("GenericReflection.Result`1");
    var closedResultType2 = openResultType2.MakeGenericType(Type.GetType("GenericReflection.Person"));
    var createdResult2 = Activator.CreateInstance(closedResultType2);
    Console.WriteLine(createdResult2.GetType());

    var methodInfo = closedResultType.GetMethod("AlterAndReturnValue");
    Console.WriteLine(methodInfo);

    var genericMethodInfo = methodInfo.MakeGenericMethod(typeof(Employee));
    genericMethodInfo.Invoke(createdResult, new object[] { new Employee() });
}
