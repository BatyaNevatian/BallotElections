::dotnet ef dbcontext scaffold --help
::
::
::Usage: dotnet ef dbcontext scaffold [arguments] [options]
::
::Arguments:
::  <CONNECTION>  The connection string to the database.
::  <PROVIDER>    The provider to use. (E.g. Microsoft.EntityFrameworkCore.SqlServer)
::
::Options:
::  -d|--data-annotations                  Use attributes to configure the model (where possible). If omitted, only the fluent API is used.
::  -c|--context <NAME>                    The name of the DbContext.
::  --context-dir <PATH>                   The directory to put DbContext file in. Paths are relative to the project directory.
::  -f|--force                             Overwrite existing files.
::  -o|--output-dir <PATH>                 The directory to put files in. Paths are relative to the project directory.
::  --schema <SCHEMA_NAME>...              The schemas of tables to generate entity types for.
::  -t|--table <TABLE_NAME>...             The tables to generate entity types for.
::  --use-database-names                   Use table and column names directly from the database.
::  --json                                 Show JSON output.
::  -p|--project <PROJECT>                 The project to use.
::  -s|--startup-project <PROJECT>         The startup project to use.
::  --framework <FRAMEWORK>                The target framework.
::  --configuration <CONFIGURATION>        The configuration to use.
::  --runtime <RUNTIME_IDENTIFIER>         The runtime to use.
::  --msbuildprojectextensionspath <PATH>  The MSBuild project extensions path. Defaults to "obj".
::  --no-build                             Don't build the project. Only use this when the build is up-to-date.
::  -h|--help                              Show help information
::  -v|--verbose                           Show verbose output.
::  --no-color                             Don't colorize output.
::  --prefix-output                        Prefix output with level.

dotnet ef dbcontext scaffold "------" Microsoft.EntityFrameworkCore.SqlServer -c BaseDataContext --use-database-names -d -f --context-dir DAL/Context -o DAL/Context --json  -p BallotElectionsDAL.csproj --no-build -v  -t T_Party  -t T_Voter -t T_VoterInParty  -t T_VoterPassword -t T_Permission -t  T_VoterPermission
pause