using AbstractFactory.Products;

namespace AbstractFactory.Factories;

public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}
