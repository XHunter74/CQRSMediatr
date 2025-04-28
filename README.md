[![NuGet](https://img.shields.io/nuget/v/cqrs-mediatr)](https://www.nuget.org/packages/cqrs-mediatr)
[![NuGet Downloads](https://img.shields.io/nuget/dt/cqrs-mediatr.svg)](https://www.nuget.org/packages/cqrs-mediatr/)

# CQRSMediatr

CQRSMediatr is a .NET library that implements the Command Query Responsibility Segregation (CQRS) pattern using the Mediator design pattern. It provides interfaces and base implementations to simplify the development of CQRS-based applications.

## Features

- **Command and Query Separation**: Clearly separates commands (write operations) from queries (read operations).
- **Handler Abstraction**: Provides interfaces for command and query handlers.
- **Extensibility**: Easily extendable to fit your application's needs.

## Project Structure

- **Interfaces/**: Contains core interfaces such as `ICommand`, `ICommandHandler`, `IQuery`, `IQueryHandler`, and `ICQRSMediatr`.
- **RegisterCqrsMediatr.cs**: Handles the registration of CQRS and Mediator components.
- **CqrsMediatr.cs**: Main implementation file for the library.

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later

### Installation

1. From NuGet package repository:
   ```bash
   dotnet add package cqrs-mediatr
   ```

From sources:
1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd CQRSMediatr
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run tests (if applicable):
   ```bash
   dotnet test
   ```

### Usage

1. Define your commands and queries by implementing `ICommand` and `IQuery` interfaces.
2. Create handlers for your commands and queries by implementing `ICommandHandler` and `IQueryHandler` interfaces.
3. Register the handlers and mediator in your application's dependency injection container using `RegisterCqrsMediatr.cs`.

Example:

```csharp
public class CreateOrderCommand : ICommand {
    public string OrderId { get; set; }
    public string ProductName { get; set; }
}

public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand> {
    public Task Handle(CreateOrderCommand command) {
        // Handle the command logic here
        return Task.CompletedTask;
    }
}
```

### Registering in Dependency Injection (DI) Container

To register the CQRS Mediator in your application's DI container, use the following code in your `Startup` class or equivalent:

```csharp
services.AddCqrsMediatr(typeof(Startup));
```

This will scan and register all command and query handlers in the assembly containing the specified type (`Startup` in this case).

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

MIT License

Copyright (c) 2025 Serhiy Krasovskyy xhunter74@gmail.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
