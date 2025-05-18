@echo off

dotnet lambda package --project-location .\src\DynamicString -o lambda.zip --configuration Release --framework net8.0 --name dynamic_string_function

if errorlevel 1 (
    echo Error occurred during packaging.
    exit /b 1
)