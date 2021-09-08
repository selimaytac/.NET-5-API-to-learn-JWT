# Simple .NET 5 API to learn JWT.

***(It's just a simple api to learn.)***
### .Net Version: .NET 5 ###
## Installation
```bash
git clone https://github.com/selimaytac/.NET-5-API-to-learn-JWT.git
```
## Packages & Dependencies
Name    | Version 
------------- | -------------
Microsoft.AspNetCore.Authentication.JwtBearer  |   5.0.9
Microsoft.AspNetCore.Identity  |  2.2.0
Microsoft.AspNetCore.Identity.EntityFrameworkCore  |  5.0.9
Microsoft.EntityFrameworkCore.SqlServer  |  5.0.9
Microsoft.EntityFrameworkCore.Tools  |  5.0.9
Swashbuckle.AspNetCore  |  6.2.1
AutoMapper.Extensions.Microsoft.DependencyInjection  |  8.1.1

## Usage

#### 1. Build database
     1. Edit your connection string in appsettings.json.
     2. Add migration
     3. Update database

#### 2. First, create a user record.

#### 3. First of all, turn the bottom part into a comment line and create an admin record. Then you have an admin record that can try the admin signup part.
```csharp
    var recorder = await _userManager.FindByIdAsync(model.recorderId);
    var isAdmin = await _userManager.GetRolesAsync(recorder);

    if (!isAdmin.Contains(UserRoles.Admin))
        return StatusCode(StatusCodes.Status500InternalServerError,
            new Response<NoDataResponse> {Status = "Error", Message = "You don't have enough permission!"});
```
#### 4. You can test auth operations using the token that comes after logging in with Swagger ui or postman.

#### Congratulations, you can now use the application. ####
## Contributing ###
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
## License
[MIT](https://choosealicense.com/licenses/mit/)
