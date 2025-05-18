#!/bin/bash
set -e

dotnet lambda package --project-location ./src/DynamicString -o lambda.zip --configuration Release --framework net8.0 --name dynamic_string_function