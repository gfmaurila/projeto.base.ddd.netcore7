#!/bin/bash

# Wait for SQL Server to be ready
echo "Waiting for SQL Server to be ready..."
while ! /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "@C23l10a1985" -Q "SELECT 1;" > /dev/null 2>&1
do
  sleep 1
done
echo "SQL Server is ready."

# Run migrations
echo "Running migrations..."
dotnet ef database update

# Start the app
dotnet WebAPI.dll
