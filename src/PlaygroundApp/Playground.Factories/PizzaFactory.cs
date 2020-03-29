using System;

namespace Playground.Factories
{
    public interface IPizza { }

    public class SimplePizza : IPizza { }

    /// <summary>
    /// Sample demonstaring factoriy evolution concept:
    /// starting from "Simple Factory" and ending with "Builder"
    /// </summary>
    public class PizzaFactory
    {
        public IPizza PreparePizza()
        {
            return BuildPizza_SimpleFactory();
        }

        private IPizza BuildPizza(string pizzaName) => new SimplePizza();

        private IPizza BuildPizza_SimpleFactory()
        {
            return BuildPizza("menu-item-3");
        }
    }

    public class PizzaCrust { }
    public class PizzaCheese { }
    public class PizzaToppings { }

    public class CustomPizza : IPizza
    {
        public CustomPizza (PizzaCrust pizzaCrust, PizzaCheese pizzaCheese, PizzaToppings pizzaToppings) { }
    }

    public interface IPizzaFactory {
        IPizza Build(string pizzaName);
    }

    public interface IPizzaAbstractFactory
    {
        PizzaCrust BuildCrust(string crustName);
        PizzaCheese BuildCheese(string cheeseName);
        PizzaToppings BuildToppings(string[] toppingNames);
    }

    public interface IPizzaBuilder
    {
        IPizzaBuilder SetCrust(string crustName);
        IPizzaBuilder SetCheese(string cheeseName);
        IPizzaBuilder SetTopping(string toppingName);
        IPizza Build();
    }

    public class Foo
    {
        protected IPizza _pizza;
        private IPizzaFactory _pizzaFactory;
        private IPizzaAbstractFactory _pizzaAbstractFactory;
        private IPizzaBuilder _pizzaBuilder;

        public void BuildPizza_FactoryMethod()
        {
            _pizza = _pizzaFactory.Build("menu-item-3");
        }
        public void BuildPizza_AbstractFactory()
        {
            _pizza = new CustomPizza(
                _pizzaAbstractFactory.BuildCrust("chicago-style"),
                _pizzaAbstractFactory.BuildCheese("mozzarella"),
                _pizzaAbstractFactory.BuildToppings(new string[] { "pineapple", "ham" })
            );
        }
        public void BuildPizza_BuilderPattern()
        {
            _pizza = _pizzaBuilder
                .SetCrust("chicago-style")
                .SetCheese("mozzarella")
                .SetTopping("pineapple")
                .SetTopping("ham")
                .Build();
        }
    }

}