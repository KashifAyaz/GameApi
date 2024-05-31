# GameApi
-> This GameApi project contains an ASP.NET Core Web API framework.
-> Framework version .NET 8 
-> Repository Pattren

Default user(player) login Cradintials
username : player1
password : player1pass

VIP Character(admin) login Cradintials
username : admin1
password : admin1pass

api end point
https://localhost:7061/api/Auth/login

body 

{
  username:"string",
  password:"string"
}

for admin user

{
  "username":"admin1",
  "password":"admin1pass"
}

for default user

{
  "username":"player1",
  "password":"player1pass"
}