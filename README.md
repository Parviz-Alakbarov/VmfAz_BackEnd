# <p align="center">VMF.az</p>

GoldenCar is a car rental solution. This project includes an enterprise-grade solution for building RESTful services using ASP.NET WebAPI and C#.

### Usage
 
After publishing the Web API, you can make HTTP requests like:
   
   ```sh
   https://localhost:44372/api/`CONTROLLER_NAME`/`METHOD_NAME`
   ```
   
 #### Sample HTTP GET requests:

1. List all products:
   ```sh
   https://localhost:44337/api/products/getall
   ```
2. List paginated products:
   ```sh
   https://localhost:44337/api/products/getpaginatedlist?PageNumber=1&BrandIds=2&GenderIds=1
   ```
3. List all vehicle colors:
   ```sh
   https://localhost:44337/api/orders/track?guid=fdccc323-bdda-468e-b5fb-3b3e014e86c5
   ```



## Tech Stack
| Technology / Library | Version |
| ------------- | ------------- |
| .NET | 5.0 |
| Autofac | 6.3.0 |
| MimeKit | 3.2.0 |
| Mime-Detective | 22.7.19 |
| Newtonsoft.Json | 13.0.1 |
| FluentValidation | 10.3.6 |
| Swashbuckle.AspNetCore | 5.6.3 |
| Microsoft.AspNetCore.Http | 2.2.2 |
| Autofac.Extras.DynamicProxy | 6.0.0 |
| Microsoft.AspNetCore.Features | 5.0.9 |
| Microsoft.IdentityModel.Tokens | 6.12.2 |
| Microsoft.EntityFrameworkCore.Tools | 5.0.14 |
| Microsoft.EntityFrameworkCore.Design | 5.0.8 |
| Microsoft.AspNetCore.Http.Abstractions | 2.2.0 |
| Autofac.Extensions.DependencyInjection | 7.2.0 |
| Microsoft.EntityFrameworkCore.SqlServer | 5.0.14 |
| Microsoft.EntityFrameworkCore.Configuration | 6.0.0 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 5.0.14 |
| Microsoft.EntityFrameworkCore.Configuration.Binder | 6.0.0 |
| AutoMapper.Extensions.Microsoft.DependencyInjection | 11.0.0 |

## Associated Project

The frontend of this project [VmfAz_FrontEnd](https://github.com/Parviz-Alakbarov/VmfAz_FrontEnd)
   <br><br>
The frontend(Admin Panel) of this project [VmfAz_AdminPanel](https://github.com/Parviz-Alakbarov/VmfAz_AdminPanel)


 
