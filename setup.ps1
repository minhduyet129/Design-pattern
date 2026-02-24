# Script khoi tao moi truong nhanh chong khi chuyen sang may khac
Write-Host "=== DESIGN PATTERN LEARNING SETUP ===" -ForegroundColor Cyan

# 1. Kiem tra .NET SDK
Write-Host "1. Checking .NET SDK..." -ForegroundColor Yellow
$dotnetVersion = dotnet --version
if ($?) {
    Write-Host "   Found .NET SDK version: $dotnetVersion" -ForegroundColor Green
} else {
    Write-Host "   [ERROR] .NET SDK not found! Please install .NET SDK from https://dotnet.microsoft.com/download" -ForegroundColor Red
    Exit
}

# 2. Restore Dependencies
Write-Host "`n2. Restoring Nuget Packages..." -ForegroundColor Yellow
dotnet restore
if ($?) {
    Write-Host "   Packages restored successfully." -ForegroundColor Green
} else {
    Write-Host "   [ERROR] Failed to restore packages." -ForegroundColor Red
}

# 3. Build Solution
Write-Host "`n3. Building Solution..." -ForegroundColor Yellow
dotnet build
if ($?) {
    Write-Host "   Build Success! You are ready to code." -ForegroundColor Green
} else {
    Write-Host "   [ERROR] Build Failed." -ForegroundColor Red
}

Write-Host "`n=== READY! Check LEARNING_PROGRESS.md to continue. ===" -ForegroundColor Cyan
