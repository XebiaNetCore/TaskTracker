#!/bin/bash

###################################
### Creating the application infrastructure using shell script ###
###################################



addProjectReference(){

    dotnet add "$1" reference "$2"
}

createSolution()
{
    log "Creating solution >>  $1" 
    dotnet new sln -n "$1"
    log "Solution file created >>  $1" 

    log "Creating directories ...."
    mkdir src scripts tests


    log "Creating projects ...."
    
    cd src
    dotnet new webapi -n "$1.Api"
    dotnet new webapi -n "$1.Services.Identi
log()
{
    echo "$1" 
}ty"
    dotnet new webapi -n "$1.Services.Tasks"
    dotnet new classlib -n "$1.Common"

    log "Creating test projects projects ...."

    log "Adding reference to projects  ...."
    
        addProjectReference "$1.Api/$1.Api.csproj" reference $1.Common/$1.Common.csproject
        addProjectReference "$1.Services.Identity/$1.Services.Identity.csproj" reference $1.Common/$1.Common.csproject
        addProjectReference "$1.Services.Tasks/$1.Services.Tasks.csproj" reference $1.Common/$1.Common.csproject
    cd ..
    cd tests
    dotnet new xunit -n "$1.Api.Test"
    dotnet new xunit -n "$1.Services.Identity.Test"
    dotnet new xunit -n "$1.Services.Tasks.Test"


        log "Adding projects to solution ...."
    cd ..
    dotnet addn sln "src/$1.Api/$1.Api.csproj"
    dotnet addn sln "src/$1.Api.Common/$1.Api.Common.csproj"
    dotnet addn sln "src/$1.Api.Services.Identity/$1.Api.Services.Identity.csproj"
    dotnet addn sln "src/$1.Api.Services.Tasks/$1.Api.Services.Tasks.csproj"


}
log()
{
    echo "$1" 
}




 SOLN="";
if [ $# > 0 ]; then 
    #echo  "param exists "
    SOLN=$1;
    echo $SOLN;
fi

if  [ -n $1 ]; then
    #echo "param is not null  and value  is $1"
    createSolution $SOLN;
else
    echo "Please pass the name of solution as first argument " ;
fi 



