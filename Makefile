.PHONY: build test pack

build:
	dotnet build src/HttpContextSubstitute.sln

test:
	dotnet test src/HttpContextSubstitute.sln

coverage:
	dotnet test src/HttpContextSubstitute.sln --collect:"XPlat Code Coverage"

pack:
	dotnet pack src/HttpContextSubstitute/HttpContextSubstitute.csproj -c Release --include-source --include-symbols -o nupkgs
