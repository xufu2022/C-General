# Using Parallel LINQ (PLINQ)

> Parallelize your LINQ to speed up the execution : “Parallel implementation of the Language-Integrated Query (LINQ) pattern”


Parallel LINQ Works with Any LINQ Flavor

    var result = source
        .Select(Compute)
        .Sum(); 

    var result =
        (from i in source
            select Compute(i))
            .Sum();

Parallel LINQ
- May result in a much faster execution
- PLINQ will perform an internal analysis on the query to determine if it’s suitable for parallelization

Construct a Parallel Query from IEnumerable<T>

    IEnumerable<T> source = ...
    ParallelQuery<T> query = source.AsParallel();

    var source = new [] { 1, 2, 3, 4 };

    var query = source
        .AsParallel() // Use all available resources to process the query
        .Select(Compute);

    var result = query.Sum();

    var query = source.AsParallel().WithCancellation(token)
    var query = source.AsParallel().WithCancellation(token).WithDegreeOfParallelism(2)

    var query = source
        .AsParallel()
        .WithCancellation(token)
        .WithDegreeOfParallelism(2)
        .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
        .WithMergeOptions(ParallelMergeOptions.Default)
        .Select(Compute);

Don’t overuse AsParallel() as it adds overhead

    ParallelQuery<T> pquery = source.AsParallel();
    IEnumerable<T> squery = query.AsSequential();

    var query = source
        .AsParallel()
        .Select(Compute) // This runs in Parallel
        .AsSequential()
        .Select(...); // This does not run in Parallel

Only force parallelism if you are absolutely certain it will run faster

AsParallel()

- Don’t assume queries will automatically run faster
- Performance improvement noticeable on large collections

Considering locking best practices is important for PLINQ as well

Sequential When Queries Contain

- Select, indexed Where, indexed SelectMany, or ElementAt clause after an ordering or filtering operator that has removed or rearranged original indices
- Take, TakeWhile, Skip, SkipWhile operator and where indices in the source sequence are not in the original order
- Zip or SequenceEquals, unless one of the data sources has an originally ordered index and the other data source is indexable
- Concat, unless it is applied to indexable data sources
- Reverse, unless applied to an indexable data source

        var source = new [] { 1, 2, 3, 4 };
        var query = source
            .AsParallel()
            .AsOrdered() // Persist the order
            .Select(Compute);


Parallel Operations with the Task Parallel Library

    Task.Run(() => {});
    Parallel.For(0, 100, (i) => {});
    Parallel.ForEach(elements, (e) => {});
    Parallel.Invoke(() => {});
    elements.AsParallel().ForAll((e) => {});

