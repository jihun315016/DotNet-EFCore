    using PizzaApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// new input START *****
// Add the PizzaContext
// AddSqlite<PizzaContext> : SQLite Provider�� ����ϵ��� �����ϰ�, PizzaContext ��ü�� ������ ���� �����̳ʿ� ���
// ��ϵ� PizzaContext �ν��Ͻ��� �ʿ�� �ϴ� Ŭ������ ���񽺿� ���Եȴ�.
// -> ���� �ش� Ŭ������ ���񽺿��� PizzaContext �ν��Ͻ��� ���� �����ϰų� ������ �ʿ� ���� �̹� �غ�� PizzaContext �ν��Ͻ��� ����Ͽ� �۾��� �� �ִ�.
// -> ��� : �����ͺ��̽��� �۾��� �� �ִ� PizzaContext �ν��Ͻ��� ���� �� ��ü�� �ʿ��� ���� �ڵ����� �������ְڴٴ� �ǹ�
// Data Source=ContosoPizza.db : SQLite �����ͺ��̽� ���� ���ڿ� -> �����ͺ��̽� ������ ContosoPizza.db�� ����
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");



// Add the PromotionsContext
// new input END *****



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// �����ͺ��̽� �õ�
app.CreateDbIfNotExists();

app.Run();
