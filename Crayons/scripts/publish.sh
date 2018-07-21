(cd ..; dotnet restore)
(cd ..; dotnet build)
(cd ../src/Crayons.Api; dotnet publish -o "./artifacts/")