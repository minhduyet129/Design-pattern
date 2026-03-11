using Builder.Builders;

namespace Builder.Director;

public class HouseDirector
{
    private IHouseBuilder? _builder;

    public IHouseBuilder Builder
    {
        set { _builder = value; }
    }

    public void BuildSimpleHouse()
    {
        if (_builder == null)
        {
            throw new InvalidOperationException("Builder is not set.");
        }
        _builder.BuildWalls(4);
        _builder.BuildDoors(1);
        _builder.BuildWindows(2);
        _builder.BuildRoof();
    }

    public void BuildLuxuryHouse()
    {
        if (_builder == null)
        {
            throw new InvalidOperationException("Builder is not set.");
        }
        _builder.BuildWalls(8);
        _builder.BuildDoors(3);
        _builder.BuildWindows(6);
        _builder.BuildRoof();
        _builder.BuildGarage();
        _builder.BuildSwimmingPool();
        _builder.BuildGarden();
    }
}
