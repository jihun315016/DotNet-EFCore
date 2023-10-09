using PizzaApp.SQLite.Models;

namespace PizzaApp.SQLite.Data
{
    // 데이터베이스 시드
    public static class DbInitializer
    {
        public static void Initialize(PizzaContext context)
        {   
            // 데이터베이스의 세 테이블 모두 값이 있는 경우
            if(context.Pizzas.Any() && context.Toppings.Any() && context.Sauces.Any())
            {
                return;
            }


            // 데이터베이스에 값이 없다면 초기 데이터 추가
            var pepperoniTopping = new Topping { Name = "Pepperoni", Calories = 130 };
            var sausageTopping = new Topping { Name = "Sausage", Calories = 100 };
            var hamTopping = new Topping { Name = "Ham", Calories = 70 };
            var chickenTopping = new Topping { Name = "Chicken", Calories = 50 };
            var pineappleTopping = new Topping { Name = "Pineapple", Calories = 75 };

            var tomatoSauce = new Sauce { Name = "Tomato", IsVegan = true };
            var alfredoSauce = new Sauce { Name = "Alfredo", IsVegan = false };

            var pizzas = new Pizza[]
            {
                new Pizza
                    {
                        Name = "Meat Lovers",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pepperoniTopping,
                                sausageTopping,
                                hamTopping,
                                chickenTopping
                            }
                    },
                new Pizza
                    {
                        Name = "Hawaiian",
                        Sauce = tomatoSauce,
                        Toppings = new List<Topping>
                            {
                                pineappleTopping,
                                hamTopping
                            }
                    },
                new Pizza
                    {
                        Name="Alfredo Chicken",
                        Sauce = alfredoSauce,
                        Toppings = new List<Topping>
                            {
                                chickenTopping
                            }
                        }
            };

            context.Pizzas.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}