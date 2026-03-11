using Builder.Builders;
using Builder.Product;

namespace Builder.Builders;

public class ConcreteHouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public ConcreteHouseBuilder()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._house = new House();
    }

    public void BuildWalls(int walls)
    {
        this._house.Walls = walls;
    }

    public void BuildDoors(int doors)
    {
        this._house.Doors = doors;
    }

    public void BuildWindows(int windows)
    {
        this._house.Windows = windows;
    }

    public void BuildRoof()
    {
        this._house.HasRoof = true;
    }

    public void BuildGarage()
    {
        this._house.HasGarage = true;
    }

    public void BuildSwimmingPool()
    {
        this._house.HasSwimmingPool = true;
    }

    public void BuildGarden()
    {
        this._house.HasGarden = true;
    }

    public House GetResult()
    {
        House result = this._house;
        this.Reset();
        return result;
    }
}
