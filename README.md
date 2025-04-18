# TeamTaskPro

A team task management application built with ASP.NET Core and SQLite.

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/TeamTaskPro.git
   cd TeamTaskPro
   ```

2. Create the development settings file:
   ```bash
   cp src/TeamTaskPro.Web/appsettings.Development.json.example src/TeamTaskPro.Web/appsettings.Development.json
   ```

3. Update the `appsettings.Development.json` file with your configuration:
   - The default SQLite connection string is already set up
   - Modify any other settings as needed

4. Restore NuGet packages:
   ```bash
   dotnet restore
   ```

5. Run the application:
   ```bash
   dotnet run --project src/TeamTaskPro.Web
   ```

6. Open your browser and navigate to:
   ```
   http://localhost:5005
   ```

## Configuration

### Required Environment Variables

The application uses the following configuration settings:

- `ConnectionStrings:DefaultConnection`: SQLite database connection string
  - Default: `Data Source=TeamTaskPro.db`

### Identity Settings

The application uses ASP.NET Core Identity with the following default settings:

- Password Requirements:
  - Minimum length: 8 characters
  - Requires uppercase letters
  - Requires lowercase letters
  - Requires numbers
  - Requires special characters
- Account Confirmation: Required
- Two-Factor Authentication: Optional

### Admin Setup

For security reasons, admin credentials are not stored in configuration files. Instead, follow these steps to set up an admin account:

1. Register a new account through the application's registration page
2. Contact your system administrator to grant admin privileges to your account
3. Alternatively, use the database seeder to create an initial admin account (development only)

## Security Best Practices

1. Never commit credentials or sensitive information to version control
2. Use environment variables or secure configuration providers for sensitive data
3. Change default passwords immediately after setup
4. Enable two-factor authentication for admin accounts
5. Regularly update dependencies to patch security vulnerabilities
6. Follow the principle of least privilege when assigning roles

## Database

The application uses SQLite for data storage. The database file will be created automatically when you first run the application.

### Database Location

- Development: `src/TeamTaskPro.Web/TeamTaskPro.db`
- Production: Configured in `appsettings.json`

## Project Structure

```
TeamTaskPro/
├── src/
│   └── TeamTaskPro.Web/          # Main web application
│       ├── Areas/                # MVC Areas
│       ├── Controllers/          # MVC Controllers
│       ├── Data/                 # Data access layer
│       ├── Models/               # Domain models
│       ├── Views/                # Razor views
│       └── wwwroot/              # Static files
└── tests/                        # Test projects
```

## Development

### Running Tests

```bash
dotnet test
```

### Building for Production

```bash
dotnet publish -c Release
```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
