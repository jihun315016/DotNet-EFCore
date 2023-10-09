using Microsoft.EntityFrameworkCore;
using PizzaApp.SQLite.Models;

namespace PizzaApp.SQLite.Data
{
    // DbContext : 데이터베이스와 상호 작용할 수 있는 게이트웨이
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }


        // DbSet<T> : 데이터베이스에 생성될 테이블
        // 테이블 이름은 PizzaContext 클래스의 DbSet<T> 속성과 일치한다.
        public DbSet<Pizza> Pizzas => Set<Pizza>();

        public DbSet<Topping> Toppings => Set<Topping>();

        public DbSet<Sauce> Sauces => Set<Sauce>();
    }
}
