[private]
@default:
    just --list --unsorted

# Install required packages
bootstrap: bootstrap-restore bootstrap-wasm-tools

[private]
bootstrap-restore:
    dotnet restore

[private]
[unix]
bootstrap-wasm-tools:
    sudo dotnet workload install wasm-tools

[private]
[windows]
bootstrap-wasm-tools:
    dotnet workload install wasm-tools

# Run desktop version with hot-reload
watch:
    dotnet watch . --project BrokenWorld.Desktop

# Format source code
fmt:
    dotnet format .

# Prepare before commit
prepare: fmt publish-web publish-desktop

# Publish for the web
publish-web:
    dotnet publish -c Release BrokenWorld.Web

# Publish for the current host platform
publish-desktop:
    dotnet publish -c Release BrokenWorld.Desktop

# Serve web version
serve: publish-web
    python3 -m http.server -d ./BrokenWorld.Web/bin/Release/net10.0/browser-wasm/AppBundle/

# Archive web version for publishing
dist: publish-web
    cd ./BrokenWorld.Web/bin/Release/net10.0/browser-wasm/AppBundle/ \
        && zip -r ../../../../../../game.zip .
