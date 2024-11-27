FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80

# copy all .csproj files and restore as distinct layers. Use of the same COPY commands
# for every dockerfile in the project to take advantage of docker caching.

COPY PetVet.sln  PetVet.sln
COPY src/PetManageApi/PetManageApi.csproj src/PetManageApi/PetManageApi.csproj


#Restore package deps
RUN dotnet restore PetVet.sln


# Copy the app folders
COPY src/PetManageApi src/PetManageApi

WORKDIR /app/src/PetManageApi
RUN dotnet publish -c Release -o /app/src/out


#Build runtime image

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet","PetManageApi.dll" ]



