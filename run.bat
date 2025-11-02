@echo off
title Smart Vending Machine Manager - Assessment
color 0A

echo.
echo ===============================================
echo   SMART VENDING MACHINE MANAGER - ASSESSMENT
echo ===============================================
echo.
echo This application demonstrates:
echo • WPF MVVM Architecture
echo • IoT Device Management Simulation  
echo • CRUD Operations with Real-time Updates
echo • Device Communication Error Handling
echo.
echo ===============================================
echo.

echo Starting application...
timeout /t 2 /nobreak >null

echo.
echo [INFO] Launching Smart Vending Machine Manager...
echo [INFO] Close this window after testing the application.
echo.

:: Run the application WITHOUT waiting
start "" "SmartVendingMachineManager.exe"

echo.
echo ===============================================
echo   APPLICATION LAUNCHED SUCCESSFULLY!
echo ===============================================
echo.
echo ASSESSMENT FEATURES TO TEST:
echo.
echo 1. CRUD OPERATIONS:
echo    • Click 'Add New Machine' to create entries
echo    • Select machines from list to view/edit details
echo    • Use 'Update Machine' to save changes
echo    • Try 'Delete Machine' with confirmation
echo.
echo 2. REAL-TIME SIMULATION:
echo    • Watch Activity Logs for automatic updates
echo    • Observe status changes every 25 seconds
echo    • Note telemetry data every 8 seconds
echo.
echo 3. ERROR HANDLING:
echo    • Try sending commands to offline devices
echo    • Observe error messages and logging
echo.
echo 4. MVVM PATTERNS:
echo    • Data binding automatically updates UI
echo    • Commands handle user interactions
echo    • Separation of View/ViewModel/Model
echo.
echo ===============================================
echo.
echo You can now close this window.
echo The application will continue running independently.
pause