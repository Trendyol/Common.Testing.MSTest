echo off
set version=%1
set pass=%2
set nugetUrl=%3
.nuget\NuGet.exe push Common.Testing.MSTest\Common.Testing.MSTest.%version%.nupkg %pass% -s %nugetUrl%
