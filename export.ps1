$binPath = ".\StreamDeckVSC/bin/Release/netcoreapp3.1"
$identifier = "com.nicollasr.streamdeckvsc"
$pluginName = "$identifier.sdPlugin"

function clean($target) {
    dotnet clean -c Release -r $target

    if($target -eq "osx-x64") {
        Remove-Item ".\$identifier.mac.streamDeckPlugin" -Force
    } else {
        Remove-Item ".\$identifier.streamDeckPlugin" -Force
    }
}

function build($target) {
    clean $target
    dotnet build -c Release -r $target
}

function pack($target) {
    updateManifest $target

    $desiredPluginName = $pluginName

    if($target -eq "osx-x64") {
        $desiredPluginName = $desiredPluginName -replace "$identifier","$identifier.mac"
    }

    Rename-Item "$binPath/$target" "$desiredPluginName"

    .\tools\DistributionTool.exe -b -i "$binPath\$desiredPluginName" -o "$PSScriptRoot"

    Remove-Item "$binPath/$desiredPluginName" -Force -Recurse
}

function updateManifest($target) {
    if ($target -eq "osx-x64") {
        $manifestPath = "$binPath/$target/manifest.json"

        $manifest = Get-Content $manifestPath -raw | ConvertFrom-Json
        $manifest.OS[0].Platform = "mac"
        $manifest.OS[0].MinimumVersion = "10.11"

        $manifest | ConvertTo-Json -Depth 32 -Compress | Set-Content $manifestPath
    }
}

foreach ($target in "win10-x64", "osx-x64") {
    build $target
    pack $target
}