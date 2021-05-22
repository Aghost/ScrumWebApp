#!/bin/sh

# INIT variables
PROJECT_NAME="unnamed_project"
CHILD_ITEM="unnamed_child"
ITEM="unnamed_item"

ECHO "press ctrl-c"

if [ $# -lt "3" ]; then
    echo -n "project name: "
    read PROJECT_NAME
    echo -n "child item: "
    read CHILD_ITEM 
    echo -n "item: "
    read ITEM
else
    PROJECT_NAME=$1
    CHILD_ITEM=$2
    ITEM=$3
fi

# INIT project folder
mkdir $PROJECT_NAME
cd $PROJECT_NAME

# INIT project
dotnet new sln

# INIT project components
dotnet new mvc -o $PROJECT_NAME.Web
#dotnet new classlib -o $PROJECT_NAME.Data

#dotnet new wepapi -o $PROJECT_NAME.Api
#dotnet new classlib -o $PROJECT_NAME.Services
#dotnet new xuunit -o $PROJECT_NAME.Test

# ADD projects and classlibs to solution file
dotnet sln add $PROJECT_NAME.Web
#dotnet sln add $PROJECT_NAME.Data
#dotnet sln add $PROJECT_NAME.Api
#dotnet sln add $PROJECT_NAME.Services
#dotnet sln add $PROJECT_NAME.Test

# INIT DATA 
#cd $PROJECT_NAME.Data
#dotnet add package Microsoft.EntityFrameworkCore
#TODO dotnet add package Mssql database

# INIT SERVICES
# cd ../$PROJECT_NAME.Services
# dotnet add reference ../$PROJECT_NAME.Data

# INIT WEB
#cd ../$PROJECT_NAME.Web
#dotnet add package Microsoft.EntityFrameworkCore
#dotnet add package Microsoft.EntityFrameworkCore.Tools
#dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add reference ../$PROJECT_NAME.Data

# INIT TEST


# --- TODO/OPTIONAL
#DATA
#dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL   # POSTGRES

#WEB
#dotnet add package NewtonSoft.Json
