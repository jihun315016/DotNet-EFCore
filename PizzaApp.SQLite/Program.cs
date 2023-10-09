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
// AddSqlite<PizzaContext> : SQLite Provider�� ����ϵ��� �����ϰ�, PizzaContext ��ü�� ������ ���� �����̳ʿ� ���
// ��ϵ� PizzaContext �ν��Ͻ��� �ʿ�� �ϴ� Ŭ������ ���񽺿� ���Եȴ�.
// -> ���� �ش� Ŭ������ ���񽺿��� PizzaContext �ν��Ͻ��� ���� �����ϰų� ������ �ʿ� ���� �̹� �غ�� PizzaContext �ν��Ͻ��� ����Ͽ� �۾��� �� �ִ�.
// -> ��� : �����ͺ��̽��� �۾��� �� �ִ� PizzaContext �ν��Ͻ��� ���� �� ��ü�� �ʿ��� ���� �ڵ����� �������ְڴٴ� �ǹ�
// Data Source=ContosoPizza.db : SQLite �����ͺ��̽� ���� ���ڿ� -> �����ͺ��̽� ������ ContosoPizza.db�� ����
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


// �����ͺ��̽� �õ�
app.CreateDbIfNotExists();


app.Run();
