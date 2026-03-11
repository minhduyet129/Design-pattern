using Builder.Product;

namespace Builder.Builders;

public interface IHouseBuilder
{
    void Reset();
    void BuildWalls(int walls);
    void BuildDoors(int doors);
    void BuildWindows(int windows);
    void BuildRoof();
    void BuildGarage();
    void BuildSwimmingPool();
    void BuildGarden();
    House GetResult();
}
