param($installPath, $toolsPath, $package, $project)
$projectFullName = $project.FullName
$debugString = "install.ps1 executing for " + $projectFullName
Write-Host $debugString 

$projectFileInfo = new-object -typename System.IO.FileInfo -ArgumentList $projectFullName
$projectDirectory = $projectFileInfo.DirectoryName
Write-Host $projectDirectory

if($project.ProjectItems.Item("IService1.cs") -ne $null)
{
    $project.ProjectItems.Item("IService1.cs").Remove()
	remove-item "$projectDirectory\IService1.cs"
}

if($project.ProjectItems.Item("Service1.svc") -ne $null)
{
    $project.ProjectItems.Item("Service1.svc").Remove()
	remove-item "$projectDirectory\Service1.svc"
	remove-item "$projectDirectory\Service1.svc.cs"
}

if($project.ProjectItems.Item("App_Data") -ne $null)
{
    $project.ProjectItems.Item("App_Data").Remove()
	remove-item "$projectDirectory\App_Data" -recurse
}

$debugString = "install.ps1 complete" + $projectFullName
Write-Host $debugString
