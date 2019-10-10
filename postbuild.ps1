param($params)

$arguments = $params.replace("`"", "").split(',') # MTF double quote thing

$targetName = $arguments[0]
$targetDir = $arguments[1]

taskkill /f /im "StreamDeck.exe"

taskkill /f /im "$targetName.exe"

$pluginPath = "$env:APPDATA\Elgato\StreamDeck\Plugins\$targetName.sdPlugin"

Remove-Item -Path "$pluginPath" -Force -Recurse

Copy-Item -Path "$targetDir" -Destination "$pluginPath" -Force -Recurse -Container: $false -Exclude "*.pdb"

Start-Process -FilePath "C:\Program Files\Elgato\StreamDeck\StreamDeck.exe"

Remove-Item "$PSScriptRoot\$targetName.streamDeckPlugin"

Start-Process -FilePath "$PSScriptRoot\tools\DistributionTool.exe" -ArgumentList "-b -i `"$pluginPath`" -o `"$PSScriptRoot`"" -NoNewWindow