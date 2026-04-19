# Smart Vending Machine Manager

A WPF desktop application for managing IoT vending machines. Built with .NET 8 and MVVM architecture.

## Download

Grab the latest release from the [Releases](../../releases) page — no installation required, just extract and run.

## Run from Source

**Requirements:** Windows 10/11

1. Clone the repository
2. Double-click `run.bat`

The script automatically installs .NET 8 SDK (via winget) if missing, restores packages, builds, and launches the app.

## Features

- **Machine Management** — Add, update, and delete vending machines with full detail tracking (ID, location, status, stock capacity)
- **Real-time Simulation** — Machine statuses auto-update every 25 seconds; telemetry data refreshes every 8 seconds
- **Activity Log** — Every operation is timestamped and logged automatically
- **Error Handling** — Sending commands to offline machines is handled gracefully with descriptive error messages

## Tech Stack

- .NET 8 / WPF
- MVVM pattern via [CommunityToolkit.Mvvm](https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/)
- Data binding, commands, observable properties

## License

MIT — see [LICENSE](LICENSE)
