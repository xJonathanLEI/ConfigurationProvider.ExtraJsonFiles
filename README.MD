# Extra JSON Files Configuration Provider

## Introduction

This package doesn't actually contain a configuration provider. It's rather an extension method on `IConfigurationBuilder` that uses [Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json) under the hood.

By calling `AddExtraJsonFiles()`, the configuration builder loads JSON files located at paths pointed by the following config items:

- EXTRA_JSON_CONFIG_FILE
- EXTRA_JSON_CONFIG_FILE_0
- EXTRA_JSON_CONFIG_FILE_1
- EXTRA_JSON_CONFIG_FILE_2
- EXTRA_JSON_CONFIG_FILE_3
- ...

The extension always loads files `EXTRA_JSON_CONFIG_FILE`, `EXTRA_JSON_CONFIG_FILE_0` and `EXTRA_JSON_CONFIG_FILE_1`. All other files are loaded if and only if the previous config item is specified (the file pointed by it doesn't necessary exist though).

## Why

This extension is handy when deploying applications in [Docker Swarm mode](https://docs.docker.com/engine/swarm/) and configuring them with [Docker Configs](https://docs.docker.com/engine/swarm/configs/). Instead of hard-coding config file paths, this extension allows paths to be specified at runtime.

## Installation

The fastest way to install the package is via [NuGet](https://www.nuget.org/packages/ConfigurationProvider.ExtraJsonFiles):

    dotnet add package ConfigurationProvider.ExtraJsonFiles

## Usage

Simply call the extension method on the `IHostBuilder`:

    builder.AddExtraJsonFiles();
