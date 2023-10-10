from mcr.microsoft.com/dotnet/framework/sdk:7.0

workdir /app

# copy all files necessary to resolve dependencies
copy    MainForms.sln .
copy    MainForms/MainForms.csproj MainForms/


# resolve dependencies
run     dotnet restore --verbosity normal

# copy all files
copy    . .

# build the app
workdir /app/myproject
run     dotnet build