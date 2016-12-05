#!/bin/bash

set -e

dbserver="${DB_HOSTNAME}"
if [ -z "$dbserver" ]; then 
    dbserver="dbserver"
fi

dbport="${DB_PORT}"
if [ -z "$dbport" ]; then
    dbport=5432
fi

until nc -z $dbserver $dbport; do
    echo "$(date) - waiting for ${dbserver}:${dbport}..."
    sleep 1
done

# How to apply migrations before the application launches
dotnet ef database update

# Run sql file"
psql -h postgres --username postgres -d POSTGRES_USER -a -f /app/static.sql

# Start web app
echo "Starting web app"
dotnet run