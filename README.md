<p align="center">
  <a href="https://github.com/latuconsinafr/dating-mobile-app-api" target="blank"><img src="https://cdn.icon-icons.com/icons2/1803/PNG/512/valentine-day18_114902.png" width="200" alt="Dating App Logo" /></a>
</p>

[circleci-image]: https://img.shields.io/circleci/build/github/nestjs/nest/master?token=abc123def456
[circleci-url]: https://circleci.com/gh/nestjs/nest

  <p align="center">This is a sample application of a dating mobile app similar to <a href="https://tinder.com/">Tinder</a>/<a href="https://bumble.com/">Bumble</a>. <br />Built from scratch on top of .NET Core framework and under RESTful APIs architecture.</p>

## Description

## Application structure

    .
    ├── .vscode                         # Contains configuration files that customize the workspace settings, extensions, and debug configurations.
    |    ├── tasks.json                 # Defines tasks that can be run from the VS Code command palette.
    |    ├── launch.json                # Defines debug configuration for the project.
    ├── src                             # Main code files.
    |    ├── DatingApp.Core             # This is the domain model.
    |    ├── DatingApp.Infrastructure   # The only project that should have code concerned with EF, Files, Email, etc.
    |    ├── DatingApp.Application      # The layer contains the application logic.
    |    └── DatingApp.Web              # The entry point of the application (or the presentation), in this case, API.
    └── ...

> Please follow the current folder & file structure 
  
## Installation and running the app

You can run the solution or the web project itself. If you encountered any HTTPS development certificate, follow the instructions available on the official documentation [here](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio-code#tabpanel_3_visual-studio-code). Or you can simply type

```sh
dotnet dev-certs https --trust
```

## Support

This sample application is built on top of the .NET Core framework. If you want to support the author, you can reach the author [here](mailto:faristalatuconsina@gmail.com).

## Stay in touch

- Author - [Farista Latuconsina](mailto::faristalatuconsina@gmail.com)
- Twitter - [@latuconsinafr](https://twitter.com/latuconsinafr)

## License

This application is [MIT licensed](LICENSE).
