$ScriptsPath = '../Api/Database'
$ScriptsFullPath = Resolve-Path -Path $ScriptsPath

$command = "docker run --rm --network=int.avanssur.axadeveloperdashboard.databases -v ${ScriptsFullPath}:/flyway/sql flyway/flyway:7.0 -url=jdbc:mysql://int.avanssur.axadeveloperdashboard.db -schemas=axadashboard -user=axadashboard -password=axadashboard migrate"

Invoke-Expression $command