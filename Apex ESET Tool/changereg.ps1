$registryPath = "HKLM:\Software\Microsoft\Windows NT\CurrentVersion\Winlogon"
$Name = "Shell"
$value = "explorer.exe,esetuninstaller.exe"
New-ItemProperty -Path $registryPath -Name $name -Value $value `
    -PropertyType ExpandString -Force | Out-Null