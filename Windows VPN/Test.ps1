[System.Reflection.Assembly]::LoadWithPartialName('PresentationFramework') | Out-Null

[xml]$xaml = @"
<Window 
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    x:Name="Window" Title="Initial Window" WindowStartupLocation = "CenterScreen"
    SizeToContent = "WidthAndHeight" ShowInTaskbar = "True" Background = "lightgray"> 
    <StackPanel>
    <ComboBox x:Name="ComboBox1">
        <ComboBoxItem>PPTP</ComboBoxItem>
        <ComboBoxItem>L2TP</ComboBoxItem>
    </ComboBox>
</StackPanel>
</Window>
"@

$reader = (New-Object System.Xml.XmlNodeReader $xaml)
$Window = [Windows.Markup.XamlReader]::Load($reader)

$ComboBox1 = $Window.FindName("ComboBox1")

$ComboBox1.add_SelectionChanged( { 

    param($sender, $args)

    $selected = $sender.SelectedItem.Content
    Write-Host $selected
} )


$Window.Showdialog() | Out-Null