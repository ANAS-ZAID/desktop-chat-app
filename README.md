# Desktop Chat App

A desktop chat application built with C# Windows Forms and .NET Framework 4.8.

## Project Structure

- `Server/` - TCP chat server and server-side controllers.
- `ChatUser/` - Windows Forms desktop chat client.
- `test/` - Older client test copies kept for reference.
- `db.txt` - SQL Server database schema and sample data.

## Requirements

- Windows
- Visual Studio 2022 with .NET Framework 4.8 development tools
- SQL Server
- SQL Server database named `chat`

## Database Setup

1. Open `db.txt` in SQL Server Management Studio.
2. Execute the script to create the `chat` database, tables, and sample users.
3. The application uses Windows integrated authentication with this connection string:

```text
Server=localhost;DataBase=chat;Integrated Security=true
```

## Run the Application

1. Open `Server/Server.sln` in Visual Studio.
2. Build and run the `Server` project first.
3. Open `ChatUser/ChatUser.sln`.
4. Build and run the `ChatUser` project.
5. The server listens on TCP port `5050`.

The client is configured to connect to `127.0.0.2:5050` by default.

## Sample Login

The database script includes these sample users. The client uses the phone number as the login identifier.

- Phone: `730000001`
- Password: `pass123`

Other sample users use the same password: `770000002`, `780000003`, and `710000004`.

## Notes

- Build output folders and NuGet package folders are excluded by `.gitignore`.
- Do not commit real passwords, connection strings containing secrets, or private user data.
