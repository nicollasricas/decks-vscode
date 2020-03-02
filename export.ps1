$targets = "win10-x64", "osx-x64"
$binPath = ".\StreamDeckVSC/bin/Release/netcoreapp3.1"
$pluginName = "com.nicollasr.streamdeckvsc.sdPlugin"

function clean($target) {
    dotnet clean -c Release -r $target
    Remove-Item ".\com.nicollasr.streamdeckvsc.$target.streamDeckPlugin" -Force
}

function build($target) {
    clean $target
    dotnet build -c Release -r $target
}

function pack($target) {
    updateManifest $target

    Rename-Item "$binPath/$target" "$pluginName"

    .\tools\DistributionTool.exe -b -i "$binPath\$pluginName" -o "$PSScriptRoot"

    Remove-Item "$binPath/$pluginName" -Force -Recurse

    Rename-Item ".\com.nicollasr.streamdeckvsc.streamDeckPlugin" "com.nicollasr.streamdeckvsc.$target.streamDeckPlugin"
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

foreach ($target in $targets) {
    build $target
    pack $target
}