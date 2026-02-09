# Step To Start
```
cd AddressBookSonarQube
docker run -p 9000:9000 sonarqube:community
dotnet sonarscanner begin /k:"AddressBookSolution" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_c33a47ab958506d4e8959e7edb26353e12a94341"
dotnet build
dotnet sonarscanner end /d:sonar.token="sqp_c33a47ab958506d4e8959e7edb26353e12a94341"
cd AddressBookSonarQube.ConsoleApp
dotnet run
```

## View
PS C:\v\dotnet-project\AddressBookSonarQube> dotnet sonarscanner begin /k:"AddressBookSolution" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="sqp_c33a47ab958506d4e8959e7edb26353e12a94341"
SonarScanner for .NET 11.0
Using the .NET Core version of the Scanner for .NET
Pre-processing started.
Preparing working directories...
18:24:49.777  Updating build integration targets...
18:24:49.902  Using SonarQube v26.1.0.118079.
18:24:50.123  Fetching analysis configuration settings...
18:24:50.983  Provisioning analyzer assemblies for cs...
18:24:50.983  Installing required Roslyn analyzers...
18:24:50.984  Processing plugin: csharp version 10.17.0.131074
18:24:51.244  Provisioning analyzer assemblies for vbnet...
18:24:51.245  Installing required Roslyn analyzers...
18:24:51.245  Processing plugin: vbnet version 10.17.0.131074
18:24:51.252  Incremental PR analysis: Base branch parameter was not provided.
18:24:51.253  Cache data is empty. A full analysis will be performed.
18:24:51.283  Pre-processing succeeded.
PS C:\v\dotnet-project\AddressBookSonarQube> dotnet build
Restore complete (0.7s)
  AddressBookSonarQube.Core net10.0 succeeded with 1 warning(s) (0.8s) → AddressBookSonarQube.Core\bin\Debug\net10.0\AddressBookSonarQube.Core.dll
    C:\v\dotnet-project\AddressBookSonarQube\AddressBookSonarQube.Core\Services\AddressBookService.cs(12,45): warning S2933: Make '_books' 'readonly'. (https://rules.sonarsource.com/csharp/RSPEC-2933)
  AddressBookSonarQube.Tests net10.0 succeeded (0.7s) → AddressBookSonarQube.Tests\bin\Debug\net10.0\AddressBookSonarQube.Tests.dll
  AddressBookSonarQube.ConsoleApp net10.0 succeeded with 1 warning(s) (0.9s) → AddressBookSonarQube.ConsoleApp\bin\Debug\net10.0\AddressBookSonarQube.ConsoleApp.dll
    C:\v\dotnet-project\AddressBookSonarQube\AddressBookSonarQube.ConsoleApp\Program.cs(27,35): warning S1192: Define a constant instead of using this literal 'Book: ' 4 times. (https://rules.sonarsource.com/csharp/RSPEC-1192)

Build succeeded with 2 warning(s) in 2.6s
PS C:\v\dotnet-project\AddressBookSonarQube> dotnet sonarscanner end /d:sonar.token="sqp_c33a47ab958506d4e8959e7edb26353e12a94341"
SonarScanner for .NET 11.0
Using the .NET Core version of the Scanner for .NET
Post-processing started.
18:25:14.818  Starting with Scanner for .NET v8 the way the `sonar.projectBaseDir` property is automatically detected has changed and this has an impact on the files that are analyzed and other properties that are resolved relative to it like `sonar.exclusions` and `sonar.test.exclusions`. If you would like to customize the behavior, please set the `sonar.projectBaseDir` property to point to a directory that contains all the source code you want to analyze. The path may be relative (to the directory from which the analysis was started) or absolute.
18:25:14.92  Using Java found in Analysis Config: C:\Users\pmdhrs\.sonar\cache\39c5e23f3ce4d420663afba8ffde28034b72e2b3e240943dc2321bc1f912eef9\OpenJDK21U-jre_x64_windows_hotspot_21.0.9_10.zip_extracted\jdk-21.0.9+10-jre/bin/java.exe
18:25:15.516  INFO: Starting SonarScanner Engine...
18:25:15.518  INFO: Java 21.0.9 Eclipse Adoptium (64-bit)
18:25:16.607  INFO: Load global settings
18:25:16.732  INFO: Load global settings (done) | time=128ms
18:25:16.736  INFO: Server id: 147B411E-AZw9SdsahplVPE5WkIf9
18:25:16.749  INFO: Loading required plugins
18:25:16.75  INFO: Load plugins index
18:25:16.833  INFO: Load plugins index (done) | time=84ms
18:25:16.834  INFO: Load/download plugins
18:25:17.556  INFO: Load/download plugins (done) | time=722ms
18:25:17.932  INFO: Process project properties
18:25:17.955  INFO: Process project properties (done) | time=25ms
18:25:17.984  INFO: Project key: AddressBookSolution
18:25:17.988  INFO: Base dir: C:\v\dotnet-project\AddressBookSonarQube
18:25:17.989  INFO: Working dir: C:\v\dotnet-project\AddressBookSonarQube\.sonarqube\out\.sonar
18:25:18.024  INFO: Load project settings for component key: 'AddressBookSolution'
18:25:18.048  INFO: Load project settings for component key: 'AddressBookSolution' (done) | time=44ms
18:25:18.091  INFO: Load quality profiles
18:25:18.306  INFO: Load quality profiles (done) | time=215ms
18:25:18.378  INFO: Load active rules
18:25:19.339  INFO: Load active rules (done) | time=961ms
18:25:19.356  INFO: Load analysis cache
18:25:19.372  INFO: Load analysis cache (404) | time=17ms
18:25:19.477  INFO: Preprocessing files...
18:25:19.752  INFO: 2 languages detected in 23 preprocessed files (done) | time=274ms
18:25:19.754  INFO: 0 files ignored because of scm ignore settings
18:25:19.755  INFO: Loading plugins for detected languages
18:25:19.761  INFO: Load/download plugins
18:25:19.903  INFO: Load/download plugins (done) | time=147ms
18:25:20.035  INFO: Executing phase 2 project builders
18:25:20.085  INFO: Executing phase 2 project builders (done) | time=51ms
18:25:20.099  INFO: Load project repositories
18:25:20.279  INFO: Load project repositories (done) | time=180ms
18:25:20.314  INFO: Indexing files...
18:25:20.315  INFO: Project configuration:
18:25:20.316  INFO: Indexing files of module 'AddressBookSonarQube.Tests'
18:25:20.317  INFO:   Base dir: C:\v\dotnet-project\AddressBookSonarQube\AddressBookSonarQube.Tests
18:25:20.318  INFO:   Test paths: obj/AddressBookSonarQube.Tests.csproj.nuget.dgspec.json, obj/pr...
18:25:20.337  INFO: Indexing files of module 'AddressBookSonarQube.Core'
18:25:20.338  INFO:   Base dir: C:\v\dotnet-project\AddressBookSonarQube\AddressBookSonarQube.Core
18:25:20.338  INFO:   Source paths: Exceptions/AddressBookException.cs, Interfaces/IAddressBookSe...
18:25:20.351  INFO: Indexing files of module 'AddressBookSonarQube.ConsoleApp'
18:25:20.352  INFO:   Base dir: C:\v\dotnet-project\AddressBookSonarQube\AddressBookSonarQube.ConsoleApp
18:25:20.354  INFO:   Source paths: obj/AddressBookSonarQube.ConsoleApp.csproj.nuget.dgspec.json,...
18:25:20.361  INFO: Indexing files of module 'AddressBookSolution'
18:25:20.361  INFO:   Base dir: C:\v\dotnet-project\AddressBookSonarQube
18:25:20.363  INFO:   Source paths: dotnet-tools.json
18:25:20.363  INFO: 23 files indexed (done) | time=48ms
18:25:20.364  INFO: Quality profile for cs: Sonar way
18:25:20.364  INFO: Quality profile for json: Sonar way
18:25:20.364  INFO: ------------- Run sensors on module AddressBookSonarQube.Tests
18:25:20.411  INFO: Load metrics repository
18:25:20.471  INFO: Load metrics repository (done) | time=60ms
18:25:20.902  INFO: Sensor IaC CloudFormation Sensor [iac]
18:25:20.908  INFO: There are no files to be analyzed for the CloudFormation language
18:25:20.909  INFO: Sensor IaC CloudFormation Sensor [iac] (done) | time=8ms
18:25:20.909  INFO: Sensor IaC cfn-lint report Sensor [iac]
18:25:20.91  INFO: Sensor IaC cfn-lint report Sensor [iac] (done) | time=1ms
18:25:20.91  INFO: Sensor IaC hadolint report Sensor [iac]
18:25:20.911  INFO: Sensor IaC hadolint report Sensor [iac] (done) | time=0ms
18:25:20.913  INFO: Sensor IaC Azure Resource Manager Sensor [iac]
18:25:20.914  INFO: There are no files to be analyzed for the Azure Resource Manager language
18:25:20.916  INFO: Sensor IaC Azure Resource Manager Sensor [iac] (done) | time=2ms
18:25:20.916  INFO: Sensor Java Config Sensor [iac]
18:25:20.917  INFO: There are no files to be analyzed for the Java language
18:25:20.917  INFO: Sensor Java Config Sensor [iac] (done) | time=5ms
18:25:20.918  INFO: Sensor IaC Docker Sensor [iac]
18:25:20.918  INFO: There are no files to be analyzed for the Docker language
18:25:20.918  INFO: Sensor IaC Docker Sensor [iac] (done) | time=1ms
18:25:20.919  INFO: Sensor C# Project Type Information [csharp]
18:25:20.92  INFO: Sensor C# Project Type Information [csharp] (done) | time=1ms
18:25:20.92  INFO: Sensor C# Analysis Log [csharp]
18:25:20.932  INFO: Roslyn version: 5.0.0.0
18:25:20.932  INFO: Language version: CSharp14
18:25:20.932  INFO: Concurrent execution: enabled
18:25:20.932  INFO: Sensor C# Analysis Log [csharp] (done) | time=13ms
18:25:20.933  INFO: Sensor C# Method Declarations [csharp]
18:25:20.936  INFO: Sensor C# Method Declarations [csharp] (done) | time=4ms
18:25:20.936  INFO: Sensor C# Telemetry [csharp]
18:25:20.94  INFO: Sensor C# Telemetry [csharp] (done) | time=5ms
18:25:20.941  INFO: Sensor C# Telemetry Json [csharp]
18:25:20.96  INFO: Sensor C# Telemetry Json [csharp] (done) | time=20ms
18:25:20.961  INFO: Sensor C# Properties [csharp]
18:25:20.962  INFO: Sensor C# Properties [csharp] (done) | time=2ms
18:25:20.965  INFO: ------------- Run sensors on module AddressBookSonarQube.ConsoleApp
18:25:21.059  INFO: Sensor IaC CloudFormation Sensor [iac]
18:25:21.092  INFO: There are no files to be analyzed for the CloudFormation language
18:25:21.115  INFO: Sensor IaC CloudFormation Sensor [iac] (done) | time=34ms
18:25:21.115  INFO: Sensor IaC cfn-lint report Sensor [iac]
18:25:21.115  INFO: Sensor IaC cfn-lint report Sensor [iac] (done) | time=0ms
18:25:21.116  INFO: Sensor IaC hadolint report Sensor [iac]
18:25:21.116  INFO: Sensor IaC hadolint report Sensor [iac] (done) | time=0ms
18:25:21.116  INFO: Sensor IaC Azure Resource Manager Sensor [iac]
18:25:21.116  INFO: There are no files to be analyzed for the Azure Resource Manager language
18:25:21.116  INFO: Sensor IaC Azure Resource Manager Sensor [iac] (done) | time=10ms
18:25:21.117  INFO: Sensor Java Config Sensor [iac]
18:25:21.117  INFO: There are no files to be analyzed for the Java language
18:25:21.117  INFO: Sensor Java Config Sensor [iac] (done) | time=2ms
18:25:21.117  INFO: Sensor IaC Docker Sensor [iac]
18:25:21.117  INFO: There are no files to be analyzed for the Docker language
18:25:21.117  INFO: Sensor IaC Docker Sensor [iac] (done) | time=0ms
18:25:21.117  INFO: Sensor C# Project Type Information [csharp]
18:25:21.12  INFO: Sensor C# Project Type Information [csharp] (done) | time=9ms
18:25:21.121  INFO: Sensor C# Analysis Log [csharp]
18:25:21.122  INFO: Roslyn version: 5.0.0.0
18:25:21.126  INFO: Language version: CSharp14
18:25:21.126  INFO: Concurrent execution: enabled
18:25:21.126  INFO: Sensor C# Analysis Log [csharp] (done) | time=3ms
18:25:21.131  INFO: Sensor C# Method Declarations [csharp]
18:25:21.131  INFO: Sensor C# Method Declarations [csharp] (done) | time=5ms
18:25:21.131  INFO: Sensor C# Telemetry [csharp]
18:25:21.132  INFO: Sensor C# Telemetry [csharp] (done) | time=4ms
18:25:21.14  INFO: Sensor C# Telemetry Json [csharp]
18:25:21.142  INFO: Sensor C# Telemetry Json [csharp] (done) | time=0ms
18:25:21.142  INFO: Sensor C# Properties [csharp]
18:25:21.144  INFO: Sensor C# Properties [csharp] (done) | time=0ms
18:25:21.149  INFO: ------------- Run sensors on module AddressBookSonarQube.Core
18:25:21.177  INFO: Sensor IaC CloudFormation Sensor [iac]
18:25:21.186  INFO: There are no files to be analyzed for the CloudFormation language
18:25:21.192  INFO: Sensor IaC CloudFormation Sensor [iac] (done) | time=10ms
18:25:21.196  INFO: Sensor IaC cfn-lint report Sensor [iac]
18:25:21.196  INFO: Sensor IaC cfn-lint report Sensor [iac] (done) | time=1ms
18:25:21.197  INFO: Sensor IaC hadolint report Sensor [iac]
18:25:21.197  INFO: Sensor IaC hadolint report Sensor [iac] (done) | time=0ms
18:25:21.197  INFO: Sensor IaC Azure Resource Manager Sensor [iac]
18:25:21.197  INFO: There are no files to be analyzed for the Azure Resource Manager language
18:25:21.197  INFO: Sensor IaC Azure Resource Manager Sensor [iac] (done) | time=2ms
18:25:21.197  INFO: Sensor Java Config Sensor [iac]
18:25:21.197  INFO: There are no files to be analyzed for the Java language
18:25:21.198  INFO: Sensor Java Config Sensor [iac] (done) | time=0ms
18:25:21.198  INFO: Sensor IaC Docker Sensor [iac]
18:25:21.198  INFO: There are no files to be analyzed for the Docker language
18:25:21.198  INFO: Sensor IaC Docker Sensor [iac] (done) | time=3ms
18:25:21.198  INFO: Sensor C# Project Type Information [csharp]
18:25:21.198  INFO: Sensor C# Project Type Information [csharp] (done) | time=0ms
18:25:21.206  INFO: Sensor C# Analysis Log [csharp]
18:25:21.209  INFO: Roslyn version: 5.0.0.0
18:25:21.209  INFO: Language version: CSharp14
18:25:21.209  INFO: Concurrent execution: enabled
18:25:21.21  INFO: Sensor C# Analysis Log [csharp] (done) | time=2ms
18:25:21.21  INFO: Sensor C# Method Declarations [csharp]
18:25:21.21  INFO: Sensor C# Method Declarations [csharp] (done) | time=0ms
18:25:21.21  INFO: Sensor C# Telemetry [csharp]
18:25:21.214  INFO: Sensor C# Telemetry [csharp] (done) | time=2ms
18:25:21.214  INFO: Sensor C# Telemetry Json [csharp]
18:25:21.214  INFO: Sensor C# Telemetry Json [csharp] (done) | time=0ms
18:25:21.215  INFO: Sensor C# Properties [csharp]
18:25:21.215  INFO: Sensor C# Properties [csharp] (done) | time=0ms
18:25:21.215  INFO: ------------- Run sensors on module AddressBookSolution
18:25:21.236  INFO: Sensor IaC CloudFormation Sensor [iac]
18:25:21.243  INFO: There are no files to be analyzed for the CloudFormation language
18:25:21.244  INFO: Sensor IaC CloudFormation Sensor [iac] (done) | time=1ms
18:25:21.244  INFO: Sensor IaC cfn-lint report Sensor [iac]
18:25:21.244  INFO: Sensor IaC cfn-lint report Sensor [iac] (done) | time=0ms
18:25:21.245  INFO: Sensor IaC hadolint report Sensor [iac]
18:25:21.245  INFO: Sensor IaC hadolint report Sensor [iac] (done) | time=0ms
18:25:21.245  INFO: Sensor IaC Azure Resource Manager Sensor [iac]
18:25:21.245  INFO: There are no files to be analyzed for the Azure Resource Manager language
18:25:21.245  INFO: Sensor IaC Azure Resource Manager Sensor [iac] (done) | time=0ms
18:25:21.245  INFO: Sensor Java Config Sensor [iac]
18:25:21.245  INFO: There are no files to be analyzed for the Java language
18:25:21.245  INFO: Sensor Java Config Sensor [iac] (done) | time=0ms
18:25:21.246  INFO: Sensor IaC Docker Sensor [iac]
18:25:21.246  INFO: There are no files to be analyzed for the Docker language
18:25:21.246  INFO: Sensor IaC Docker Sensor [iac] (done) | time=2ms
18:25:21.246  INFO: Sensor C# Project Type Information [csharp]
18:25:21.246  INFO: Sensor C# Project Type Information [csharp] (done) | time=0ms
18:25:21.247  INFO: Sensor C# Analysis Log [csharp]
18:25:21.247  INFO: Sensor C# Analysis Log [csharp] (done) | time=0ms
18:25:21.247  INFO: Sensor C# Method Declarations [csharp]
18:25:21.247  INFO: Sensor C# Method Declarations [csharp] (done) | time=0ms
18:25:21.248  INFO: Sensor C# Properties [csharp]
18:25:21.249  INFO: Sensor C# Properties [csharp] (done) | time=2ms
18:25:21.25  INFO: Sensor TextAndSecretsSensor [text]
18:25:21.268  INFO: Available processors: 4
18:25:21.269  INFO: Using 4 threads for analysis.
18:25:21.59  INFO: The property "sonar.tests" is not set. To improve the analysis accuracy, we categorize a file as a test file if any of the following is true:
  * The filename starts with "test"
  * The filename contains "test." or "tests."
  * Any directory in the file path is named: "doc", "docs", "test", "tests", "mock" or "mocks"
  * Any directory in the file path has a name ending in "test" or "tests"

18:25:21.623  INFO: Start fetching files for the text and secrets analysis
18:25:21.789  INFO: Using Git CLI to retrieve untracked files
18:25:22.008  INFO: Retrieving language associated files and files included via "sonar.text.inclusions" that are tracked by git
18:25:22.022  INFO: Starting the text and secrets analysis
18:25:22.024  INFO: 23 source files to be analyzed for the text and secrets analysis
18:25:22.193  INFO: 23/23 source files have been analyzed for the text and secrets analysis
18:25:22.203  INFO: Sensor TextAndSecretsSensor [text] (done) | time=955ms
18:25:22.206  INFO: ------------- Run sensors on project
18:25:22.399  INFO: Sensor C# Telemetry processor [csharp]
18:25:22.404  INFO: Sensor C# Telemetry processor [csharp] (done) | time=5ms
18:25:22.407  INFO: Sensor C# Telemetry Json processor [csharp]
18:25:22.414  INFO: Sensor C# Telemetry Json processor [csharp] (done) | time=9ms
18:25:22.416  INFO: Sensor C# [csharp]
18:25:22.426  INFO: Importing results from 8 proto files in 'C:\v\dotnet-project\AddressBookSonarQube\.sonarqube\out\1\output-cs'
18:25:22.541  INFO: Importing results from 8 proto files in 'C:\v\dotnet-project\AddressBookSonarQube\.sonarqube\out\2\output-cs'
18:25:22.601  INFO: Importing results from 8 proto files in 'C:\v\dotnet-project\AddressBookSonarQube\.sonarqube\out\0\output-cs'
18:25:22.665  INFO: Importing 3 Roslyn reports
18:25:22.723  INFO: Found 3 MSBuild C# projects: 2 MAIN projects. 1 TEST project.
18:25:22.724  INFO: Sensor C# [csharp] (done) | time=311ms
18:25:22.724  INFO: Sensor Analysis Warnings import [csharp]
18:25:22.725  INFO: Sensor Analysis Warnings import [csharp] (done) | time=0ms
18:25:22.725  INFO: Sensor C# File Caching Sensor [csharp]
18:25:22.732  INFO: Sensor C# File Caching Sensor [csharp] (done) | time=9ms
18:25:22.732  INFO: Sensor Zero Coverage Sensor
18:25:22.746  INFO: Sensor Zero Coverage Sensor (done) | time=13ms
18:25:22.746  INFO: ------------- Gather SCA dependencies on project
18:25:22.75  INFO: Dependency analysis skipped
18:25:22.752  INFO: SCM Publisher SCM provider for this project is: git
18:25:22.753  INFO: SCM Publisher 8 source files to be analyzed
18:25:23.255  INFO: SCM Publisher 0/8 source files have been analyzed (done) | time=502ms
18:25:23.257  WARNING: WARN: Missing blame information for the following files:
18:25:23.258  WARNING: WARN:   * AddressBookSonarQube.Core/Services/AddressBookService.cs
18:25:23.258  WARNING: WARN:   * AddressBookSonarQube.Core/Interfaces/IAddressBookService.cs
18:25:23.259  WARNING: WARN:   * AddressBookSonarQube.Core/Models/AddressBook.cs
18:25:23.259  WARNING: WARN:   * AddressBookSonarQube.ConsoleApp/Program.cs
18:25:23.259  WARNING: WARN:   * AddressBookSonarQube.Core/Exceptions/AddressBookException.cs
18:25:23.26  WARNING: WARN:   * AddressBookSonarQube.Tests/AddressBookServiceTests.cs
18:25:23.26  WARNING: WARN:   * AddressBookSonarQube.Core/Utilities/FileManager.cs
18:25:23.26  WARNING: WARN:   * AddressBookSonarQube.Core/Models/Contact.cs
18:25:23.26  WARNING: WARN: This may lead to missing/broken features in SonarQube
18:25:23.261  INFO: CPD Executor 1 file had no CPD blocks
18:25:23.262  INFO: CPD Executor Calculating CPD for 6 files
18:25:23.278  INFO: CPD Executor CPD calculation finished (done) | time=15ms
18:25:23.286  INFO: SCM revision ID 'd2773c430a943a752564366ba5c3e347d5a76937'
18:25:23.417  INFO: Analysis report generated in 129ms, dir size=291.8 kB
18:25:23.452  INFO: Analysis report compressed in 35ms, zip size=45.9 kB
18:25:23.57  INFO: Analysis report uploaded in 117ms
18:25:23.572  INFO: ANALYSIS SUCCESSFUL, you can find the results at: http://localhost:9000/dashboard?id=AddressBookSolution
18:25:23.572  INFO: Note that you will be able to access the updated dashboard once the server has processed the submitted analysis report
18:25:23.572  INFO: More about the report processing at http://localhost:9000/api/ce/task?id=ef021e26-7681-46a9-8844-05a2cd0c4abc
18:25:23.608  INFO: Analysis total time: 5.972 s
18:25:23.609  INFO: SonarScanner Engine completed successfully
18:25:23.758  The scanner engine has finished successfully
18:25:23.759  Post-processing succeeded.
PS C:\v\dotnet-project\AddressBookSonarQube> cd .\AddressBookSonarQube.ConsoleApp\
PS C:\v\dotnet-project\AddressBookSonarQube\AddressBookSonarQube.ConsoleApp> dotnet run

1.Create Book 2.Add 3.Edit 4.Delete 5.View 6.Search City 7.Search State
8.Count City 9.Count State 10.Sort Name 11.Sort City 12.Sort State 13.Exit
Enter choice : 
