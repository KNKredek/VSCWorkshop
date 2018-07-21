var target = Argument("target", "Default");
var releaseConfiguration = Argument("Configuration", "Release");
var debugConfiguration = Argument("Configuration", "Debug");
var solution = "../Crayons.sln";
var artifacts = "../artifacts/";
var packages = "../packages/";

Task("Clean")
  .Does(() =>
  {
    var directorySettings = new DeleteDirectorySettings {
      Recursive = true,
      Force = true
    };
    if (DirectoryExists(artifacts))
    {
        DeleteDirectory(artifacts, directorySettings);
    }
    if (DirectoryExists(packages))
    {
        DeleteDirectory(packages, directorySettings);
    }
  });

Task("Restore")
  .IsDependentOn("Clean")
  .Does(() =>
  {
    DotNetCoreRestore(solution);
  });

Task("Build")
  .IsDependentOn("Restore")
  .Does(() =>
  {
    DotNetCoreBuild(solution);
  });

Task("Publish")
  .IsDependentOn("Build")
  .Does(() =>
  {
    DotNetCorePublish(
              "../src/Crayons.Api/Crayons.Api.csproj",
              new DotNetCorePublishSettings()
              {
                  Configuration = releaseConfiguration,
                  OutputDirectory = artifacts,
                  ArgumentCustomization = args => args.Append("--no-restore"),
              });
  });

Task("Default")
  .IsDependentOn("Publish")
  .Does(() =>{ });



RunTarget(target);