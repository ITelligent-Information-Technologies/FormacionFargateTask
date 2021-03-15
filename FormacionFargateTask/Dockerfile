FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /app

# copy published
COPY bin/Debug/netcoreapp3.1/publish/ ./ 

# make entry point
ENTRYPOINT ["dotnet", "FormacionFargateTask.dll"]