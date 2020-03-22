#$dllvar = '[DllImport("user32.dll")] public static extern bool ShowWindow(int handle, int state);'
#add-type -name win -member $dllvar -namespace native
#[native.win]::ShowWindow(([System.Diagnostics.Process]::GetCurrentProcess() | Get-Process).MainWindowHandle, 0)

Add-Type -AssemblyName PresentationFramework

$xamlFile = "D:\Apex\Projects\Windows VPN\MainWindow.xaml"
#create window

#create window
$inputXML = Get-Content $xamlFile -Raw
$inputXML = $inputXML -replace 'mc:Ignorable="d"', '' -replace "x:N", 'N' -replace '^<Win.*', '<Window'
[XML]$XAML = $inputXML

#Read XAML
$reader = (New-Object System.Xml.XmlNodeReader $xaml)
try {
    $window = [Windows.Markup.XamlReader]::Load( $reader )
} catch {
    Write-Warning $_.Exception
    throw
}
#Create variables based on form control names.
#Variable will be named as 'var_<control name>'

$xaml.SelectNodes("//*[@Name]") | ForEach-Object {
    #"trying item $($_.Name)";
    try {
        Set-Variable -Name "var_$($_.Name)" -Value $window.FindName($_.Name) -ErrorAction Stop
    } catch {
        throw
   }
}


$ComboBox1 = $Window.FindName("ComboBox1")
$ComboBox1.add_SelectionChanged( { 

    param($sender, $args)

    $Tunnel = $sender.SelectedItem.Content
    Write-Host $Tunnel
    Set-Variable -Name c -Value $Tunnel -Option Constant -Scope Global -Force
} )

$ComboBox2 = $Window.FindName("ComboBox2")
$ComboBox2.add_SelectionChanged( { 

    param($sender, $args)

    $auth = $sender.SelectedItem.Content
    Write-Host $auth
} )

$ComboBox3 = $Window.FindName("ComboBox3")
$ComboBox3.add_SelectionChanged( { 

    param($sender, $args)

    $Encryption = $sender.SelectedItem.Content
    Write-Host $Encryption
} )

Get-Variable var_*
Get-Variable -Name c -Scope Global

$var_btnQuery.Add_Click( {

    Add-VpnConnection -Name $var_Name -ServerAddress $var_Connection -TunnelType $Tunnel -EncryptionLevel $Encryption -AuthenticationMethod $auth -L2tpPsk $var_SKey -Force:$true -RememberCredential:$true -SplitTunneling:$false 
    Set-VpnConnectionUsernamePassword -connectionname $var_Name -username $var_user -password $var_pass -domain ''

       
   })
$Null = $window.ShowDialog() 