rem https://www.appveyor.com/blog/2017/03/17/codecov/

C:\Users\Stef\.nuget\packages\opencover\4.6.519\tools\OpenCover.Console.exe -target:dotnet.exe -targetargs:"test tests\SimMetrics.Net.Tests\SimMetrics.Net.Tests.csproj -c Debug --no-build" -filter:"+[SimMetrics.Net]* -[SimMetrics.Net.Tests]*" -output:coverage.xml -register:user -oldStyle