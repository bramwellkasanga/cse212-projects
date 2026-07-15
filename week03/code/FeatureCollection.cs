public class FeatureCollection
{
    // TODO Problem 5 - ADD Necessary classes and properties
    public Feature[] Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}