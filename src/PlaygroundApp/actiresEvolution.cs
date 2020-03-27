using System;

namespace Design.Deoms
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Class1
    {
        public Class1()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }

    public class PizzaCrust { }
    public class PizzaCheese { }
    public class PizzaToppings { }

    public class SimplePizza : IPizza { }
    public class CustomPizza : IPizza
    {
        public CustomPizza (PizzaCrust pizzaCrust, PizzaCheese pizzaCheese, PizzaToppings pizzaToppings) { }
    }

    public interface IPizza { }
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

        protected IPizza BuildPizza(string pizzaName) => new SimplePizza();

        public void BuildPizza_SimpleFactory()
        {
            _pizza = BuildPizza("menu-item-3");
        }
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