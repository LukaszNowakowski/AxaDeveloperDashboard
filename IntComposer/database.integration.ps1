$ScriptsPath = '../Api/Database'
$ScriptsFullPath = Resolve-Path -Path $ScriptsPath

$command = "docker run --rm -v ${ScriptsFullPath}:/flyway/sql flyway/flyway:7.0 -url=jdbc:mysql://host.docker.internal:6502 -schemas=axadashboard -user=axadashboard -password=axadashboard migrate"

Invoke-Expression $command