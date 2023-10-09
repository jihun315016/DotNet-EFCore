using PizzaApp.SQLite.Services;
using PizzaApp.SQLite.Data;
using PizzaApp.SQLite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// new input START *****
// Add the PizzaContext
// AddSqlite<PizzaContext> : SQLite Provider를 사용하도록 지정하고, PizzaContext 객체를 의존성 주입 컨테이너에 등록
// 등록된 PizzaContext 인스턴스는 필요로 하는 클래스나 서비스에 주입된다.
// -> 따라서 해당 클래스나 서비스에서 PizzaContext 인스턴스를 직접 생성하거나 관리할 필요 없이 이미 준비된 PizzaContext 인스턴스를 사용하여 작업할 수 있다.
// -> 요약 : 데이터베이스에 작업할 수 있는 PizzaContext 인스턴스를 만들어서 그 객체가 필요한 곳에 자동으로 제공해주겠다는 의미
// Data Source=ContosoPizza.db : SQLite 데이터베이스 연결 문자열 -> 데이터베이스 파일인 ContosoPizza.db과 연결
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");
builder.Services.AddScoped<PizzaService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


// 데이터베이스 시드
app.CreateDbIfNotExists();


app.Run();
