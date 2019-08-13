param($params)

$arguments = $params.replace("`"", "").split(',') # mtf double quote thing

$targetName = $arguments[0]
$targetDir = $arguments[1]

taskkill /f /im "StreamDeck.exe"

taskkill /f /im "$targetName.exe"

$pluginPath = "$env:APPDATA\Elgato\StreamDeck\Plugins\$targetName.sdPlugin"

Remove-Item -Path "$pluginPath" -Force -Recurse

Copy-Item -Path "$targetDir" -Destination "$pluginPath" -Force -Recurse -Container: $false

Start-Process -FilePath "C:\Program Files\Elgato\StreamDeck\StreamDeck.exe"