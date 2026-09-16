# Nice Rice, a Marketplace for Linux Rices

Nice Rice is a Linux marketplace for Linux rices. It features a clean architecture enforced back-end with a react front-end.

## Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/dalentri/rice_ecommerce.git
   cd rice_ecommerce
   ```

2. **Install Frontend Dependencies**

   Navigate to the `frontend` directory and install the dependencies using Bun:

   ```bash
   cd frontend
   bun install
   ```

3. **Install Backend Dependencies**

   Navigate to the `src/Web` directory and restore the .NET dependencies:

   ```bash
   cd ../src/Web
   dotnet restore
   ```

## Usage

1. **Start the Frontend**

   Run the frontend development server with Bun from the `frontend` directory:

   ```bash
   cd frontend
   bun run dev --open
   ```

2. **Start the Backend**

   Run the backend with .NET:

   ```bash
   cd src/Web
   dotnet run
   ```

   The application will now be available in the opened front-end http server at `http://localhost:5173`.

## Contributing

### Code Scaffolding

The project includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

````

## Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
````

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
