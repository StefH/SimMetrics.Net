# SimMetrics.Net
SimMetrics is a Similarity Metric Library, e.g. from edit distance's (Levenstein, etc) to other metrics (Chapman, etc).

|   | Status |
| - | ------ |
| `AppVeyor` | [![Build status](https://ci.appveyor.com/api/projects/status/lleh586owv1ee08l?svg=true)](https://ci.appveyor.com/project/StefH/simmetrics-net) |
| `Travis` | [![Build Status](https://travis-ci.org/StefH/SimMetrics.Net.svg?branch=_vs2017)](https://travis-ci.org/StefH/SimMetrics.Net) |
| `codecov.io` | [![codecov](https://codecov.io/gh/StefH/SimMetrics.Net/branch/master/graph/badge.svg)](https://codecov.io/gh/StefH/SimMetrics.Net) |
| `coveralls.io` | [![Coverage Status](https://coveralls.io/repos/github/StefH/SimMetrics.Net/badge.svg?branch=master)](https://coveralls.io/github/StefH/SimMetrics.Net?branch=master) |
| `NuGet` | [![NuGet Badge](https://buildstats.info/nuget/SimMetrics.Net)](https://www.nuget.org/packages/SimMetrics.Net) |

## Supported similarities:

- BlockDistance
- ChapmanLengthDeviation
- ChapmanMeanLength
- CosineSimilarity
- DiceSimilarity
- EuclideanDistance
- JaccardSimilarity
- Jaro 
- JaroWinkler 
- Levenstein *[Default]*
- MatchingCoefficient 
- MongeElkan
- NeedlemanWunch 
- OverlapCoefficient
- QGramsDistance
- SmithWaterman 
- SmithWatermanGotoh
- SmithWatermanGotohWindowedAffine

## Supported frameworks:
- .NET 2.0
- .NET 3.5
- .NET 4.0
- .NET 4.5 and up
- .NET Standard 1.0 to .NETStandard 1.6 (including portable, windows phone and uap)
- .NET Standard 2.0


Based on https://github.com/HamedFathi/SimMetricsCore with all the 87 unit-tests from the original project.
