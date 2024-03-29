# ms-learn-EFCore
- .NET 6.0 Web API로 구현한 Entity Framework Core 샘플 소스
- Microsoft에서 제공하는 [Entity Framework Core를 사용하여 관계형 데이터 유지 및 검색](https://learn.microsoft.com/ko-kr/training/modules/persist-data-ef-core/)을 참고한다.  
<br/>

# HTTP Request
## launchSettings.json
아래 항목에서 애플리케이션 접근 정보를 확인할 수 있다.  
**profiles - PizzaApp.SQLite - applicationUrl**  
ex) `https://localhost:xxxx`
<br/>


## Request Example
### [GET] `https://localhost:xxxx/api/Pizza`
- 모든 Pizzas 테이블 전체 항목 조회
<br/>

### [POST] `https://localhost:xxxx/api/Pizza`
```JSON
{
  "name": "delicious pizza",
  "sauce": {
    "name": "BBQ",
    "isVegan": false
  },
  "toppings": [
    {
      "name": "Cheese",
      "calories": 100
    }
  ]
}
```
- Pizzas, Sources, Toppings 데이터 추가
<br/>

### [PUT] `https://localhost:xxxx/api/Pizza/addtopping`
```JSON
{
    "pizzasId" : "4",
    "toppingsId" : "2"
}
```
- Pizzas 특정 항목에 토핑 추가
<br/>

### [DELETE] `https://localhost:xxxx/api/Pizza/deletesource`
```JSON
{
    "id" : "4"
}
```
- Pizzas 특정 항목 삭제
<br/>

# Migration
- **모델 변경 사항을 데이터베이스에 반영한다.**
1. 모델 수정 후 Migration 파일 생성
```bash
dotnet ef migrations add InitialCreate --context PizzaContext
```
PizzaContext 클래스를 기반으로 InitialCreate 이름의 Migration 파일을 생성한다.
<br/>
2. 모델 변경 사항을 데이터베이스에 적용
```bash
dotnet ef database update --context PizzaContext
```
PizzaContext 클래스와 같은 형태로 실제 데이터베이스에 적용한다.
<br/>


# Reverse Engineering
- **데이터베이스 구조를 읽어와서 소스상의 모델에 반영한다.**
1. 데이터베이스를 찾아 소스에 적용
```bash
dotnet ef dbcontext scaffold "Data Source=db/Promotions.db" Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models
```
"db/Promotions.db" 위치에 있는 Promotions 데이터베이스 기반으로 코드를 스캐폴드한다.  
--context-dir와 --output-dir는 DBContext와 모델 클래스를 위치시킬 경로를 의미한다.  
실행 결과 Data 폴더에 PromotionsContext.cs 파일이 생성되고, Models 폴더에 해당 데이터베이스의 테이블인 Coupon.cs가 생성된다.  