@echo off
dotnet test --settings nunit.runsettings --filter "FullyQualifiedName~SignInTests1|FullyQualifiedName~ContactUsTests|FullyQualifiedName~ProductDetailsTests"
pause
