@echo off
:: pushd assigns a temporary drive letter when run from a UNC path (e.g. \\wsl.localhost\...)
pushd "%~dp0"
title Smart Vending Machine Manager
color 0A

echo.
echo ===============================================
echo   SMART VENDING MACHINE MANAGER - ASSESSMENT
echo ===============================================
echo.
echo This application demonstrates:
echo   WPF MVVM Architecture
echo   IoT Device Management Simulation
echo   CRUD Operations with Real-time Updates
echo   Device Communication Error Handling
echo.
echo ===============================================
echo.

:: -----------------------------------------------
:: STEP 1: Check for .NET 8 SDK, install if missing
:: -----------------------------------------------
echo [CHECK] Looking for .NET 8 SDK...
dotnet --list-sdks 2>nul | findstr /B "8\." >nul
if %ERRORLEVEL% NEQ 0 (
    echo [INFO] .NET 8 SDK not found. Attempting to install via winget...
    echo.
    winget install --id Microsoft.DotNet.SDK.8 --silent --accept-package-agreements --accept-source-agreements
    :: winget can return non-zero even on success (e.g. 3010 = reboot pending), so
    :: verify by checking if dotnet is now on PATH instead of trusting the exit code.
    :: Reload PATH from registry first so the new install is visible.
    for /f "skip=2 tokens=3*" %%a in ('reg query "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" /v Path 2^>nul') do set "SYS_PATH=%%a %%b"
    set "PATH=%SYS_PATH%;%PATH%"
    dotnet --list-sdks 2>nul | findstr /B "8\." >nul
    if %ERRORLEVEL% NEQ 0 (
        echo.
        echo [ERROR] Automatic install failed.
        echo [INFO]  Please install .NET 8 SDK manually from:
        echo         https://dotnet.microsoft.com/download/dotnet/8.0
        echo         Then re-run this script.
        echo.
        pause
        exit /b 1
    )
)
echo [OK] .NET 8 SDK found.
echo.

:: -----------------------------------------------
:: STEP 2: Restore NuGet packages
:: -----------------------------------------------
echo [RESTORE] Downloading NuGet dependencies...
dotnet restore "SmartVendingMachineManager.sln" --verbosity quiet
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] Failed to restore packages. Check your internet connection.
    echo.
    pause
    exit /b 1
)
echo [OK] Packages restored.
echo.

:: -----------------------------------------------
:: STEP 3: Build the project
:: -----------------------------------------------
echo [BUILD] Building the application...
dotnet build "SmartVendingMachineManager.sln" --configuration Release --verbosity quiet
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] Build failed. See errors above.
    echo.
    pause
    exit /b 1
)
echo [OK] Build successful.
echo.

:: -----------------------------------------------
:: STEP 4: Launch the application
:: -----------------------------------------------
echo [INFO] Launching Smart Vending Machine Manager...
echo [INFO] Close this window after testing the application.
echo.

start "" "SmartVendingMachineManager\bin\Release\net8.0-windows\SmartVendingMachineManager.exe"

echo.
echo ===============================================
echo   APPLICATION LAUNCHED SUCCESSFULLY!
echo ===============================================
echo.
echo ASSESSMENT FEATURES TO TEST:
echo.
echo 1. CRUD OPERATIONS:
echo    - Click 'Add New Machine' to create entries
echo    - Select machines from list to view/edit details
echo    - Use 'Update Machine' to save changes
echo    - Try 'Delete Machine' with confirmation
echo.
echo 2. REAL-TIME SIMULATION:
echo    - Watch Activity Logs for automatic updates
echo    - Observe status changes every 25 seconds
echo    - Note telemetry data every 8 seconds
echo.
echo 3. ERROR HANDLING:
echo    - Try sending commands to offline devices
echo    - Observe error messages and logging
echo.
echo 4. MVVM PATTERNS:
echo    - Data binding automatically updates UI
echo    - Commands handle user interactions
echo    - Separation of View/ViewModel/Model
echo.
echo ===============================================
echo.
echo You can now close this window.
echo The application will continue running independently.
pause