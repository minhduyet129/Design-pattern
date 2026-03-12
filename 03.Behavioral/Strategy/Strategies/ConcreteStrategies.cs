using System;
using System.Collections.Generic;

namespace Strategy.Strategies;

/// <summary>
/// Concrete Strategies implement the algorithm while following the base Strategy
/// interface. The interface makes them interchangeable in the Context.
/// </summary>
public class ConcreteStrategySortAscending : IStrategy
{
    public object DoAlgorithm(object data)
    {
        var list = data as List<string>;
        if (list == null) return data;

        list.Sort();

        return list;
    }
}

public class ConcreteStrategySortDescending : IStrategy
{
    public object DoAlgorithm(object data)
    {
        var list = data as List<string>;
        if (list == null) return data;

        list.Sort();
        list.Reverse();

        return list;
    }
}
