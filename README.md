# Fable electron app step by step

This repository is an attempt to build simple electron app in fsharp using fable. The commit log of this repository recods every small step on the way.

## Requirements

* [dotnet SDK](https://www.microsoft.com/net/download/core) 3.0 or higher
* [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
* Visual Studio Code with [Ionide](http://ionide.io/) as F# editor.

##  00. Install Fable Template

The easiest way to get started with Fable is by using official Fable template.

```dotnet new -i "Fable.Template::*"```

## 01. Start a project

Open a terminal of your choice and go to (or create and then go to) an empty directory where you wan to create new Fable project. 
Once in the directory, use following command to create new Fable project

```dotnet new fable```

The above command create a project with following structure
```
/project-root-directory
    |-  /public
    |       |- fable.ico
    |       |- index.html
    |-  /src
    |       |- App.fs
    |       |- App.fsproj
    |-  .gitignore
    |-  Nuget.Config
    |-  README.md
    |-  package.json
    |-  webpack.config.js
```

## 02. .NET Core local tools

In this proejct we are going to use a couple of .NET core tools. Therefore, create local tool-manifest file using following command

```dotnet new tool-manifest```

The command creates a ```.config``` folder with ```dotnet-tool.json``` file.

## 03. Femto

One of the very useful .NET core tool, we would need is [Femto](https://github.com/Zaid-Ajaj/Femto). Please ready [Introducing Femto](https://fable.io/blog/Introducing-Femto.html) to understand it's usefulness.

Install femto using following command

```dotnet tool install femto```

The command will add the tool in the ```.config/dotnet-tool.json``` file.

We can then fire ```dotnet tool restore``` command to restore the tool.

## 04. Dependncies

**JS dependencies** are listed in the package.json file. At this stage we can run ```npm install```, which will create ```package-lock.json``` and download the packages to the ```node_modules``` folder.

**.NET dependencies** are by default listed in the src/App.csproj file. We can install them by running ```dotnet restore```. However I presfer to use [paket](https://fsprojects.github.io/Paket/)

Install paket using following command

```dotnet tool install paket```

Paket maintains dependencies using ```paket.dependencies``` file. To create this file use following command:

```dotnet paket init```

## 05. Add Electron dependencies

Since we want to build cross-plateform desktop app ussing [Electron](https://www.electronjs.org/), we need to install electron npm package as well as .NET package

Let's install .NET package using paket

```dotnet paket add Fable.Electron --project .\src\App.fsproj```

Now we need to find out which version of the electron npm pakcage is needed for Fable.Electron, and here is where we will see how Femto shines.

go to ```src``` directory and run

```dotnet femto```

and you will see following output

```
[17:48:29 INF] Analyzing project D:\spikes\fable-trial\src\App.fsproj
[17:48:29 INF] Running dotnet restore against the project
[17:48:32 INF] Using npm for package management
[17:48:33 INF] Found package.json in D:\spikes\fable-trial
[17:48:33 INF] Fable.Electron requires npm package electron
[17:48:33 INF]   | -- Required range >= 9.0 < 10 found in project file
[17:48:33 INF]   | -- Missing electron in package.json
[17:48:33 INF]   | -- Resolve manually using 'npm install electron@9.3.1 --save-dev'
```

as indicated by Femto install electron package using following command

```npm install electron@9.3.1 --save-dev```

## Webpack

[Webpack](https://webpack.js.org) is a JS bundler with extensions, like a static dev server that enables hot reloading on code changes. Fable interacts with Webpack through the `fable-loader`. Configuration for Webpack is defined in the `webpack.config.js` file. Note this sample only includes basic Webpack configuration for development mode, if you want to see a more comprehensive configuration check the [Fable webpack-config-template](https://github.com/fable-compiler/webpack-config-template/blob/master/webpack.config.js).