//SpecFlow for MSTest only supports class level parallelization.
//Each scenario is run on a single thread.
[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]
