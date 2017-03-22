dotnet clean SimMetrics.Net\SimMetrics.Net.csproj

dotnet restore SimMetrics.Net\SimMetrics.Net.csproj

dotnet build SimMetrics.Net --configuration Release --framework netstandard1.0

set FrameworkPathOverride=C:\Program Files (x86)\Mono\lib\mono\2.0-api
dotnet build SimMetrics.Net --configuration Release --framework net20
dotnet build SimMetrics.Net --configuration Release --framework net35

set FrameworkPathOverride=C:\Program Files (x86)\Mono\lib\mono\4.0-api
dotnet build SimMetrics.Net --configuration Release --framework net40

set FrameworkPathOverride=C:\Program Files (x86)\Mono\lib\mono\4.5
dotnet build SimMetrics.Net --configuration Release --framework net45

dotnet pack -c Release --no-build SimMetrics.Net
pause