
[String]$NomeSolution = read-host "Insira o nome da sua Solution: "
[String]$NomeProjeto = read-host "Insira o nome do seu projeto: "
[String]$Dest = read-host "Insira destino para onde seu projeto: "

## Move o Template para a Pasta do Projeto
$Source = (Get-Item -Path ".\").FullName
$ExcludeFiles = @('*.ps1','*.cache','*.pdb','*.dll', '*.dll.config','*.user')
$ExcludeFolders = "bin","obj","TempPE","packages"

## Copia os arquivos excluindo arquivos e pastas desnecessárias 
Get-ChildItem $Source -Recurse -Exclude $ExcludeFiles | %{ 
    $allowed = $true
    foreach ($exclude in $ExcludeFolders) { 
        if ((Split-Path $_.FullName -Parent) -Match $exclude) { 
            $allowed = $false
            break
        }
    }
    if ($allowed) {
        $_
    }
} |  Copy-Item -Destination {Join-Path $Dest $_.FullName.Substring($Source.length)}


#Rename Folders
Get-ChildItem -Path $Dest -Recurse | % { 
	Rename-Item -Path $_.PSPath -NewName $_.Name.replace("Sample",$NomeProjeto) -Force -ErrorAction SilentlyContinue
	Rename-Item -Path $_.PSPath -NewName $_.Name.replace("Template",($NomeSolution)) -Force -ErrorAction SilentlyContinue
}

#Rename Files and Content
$fileNames = Get-ChildItem -Path $Dest -File -Recurse | select -expand fullname

foreach ($filename in $filenames) 
{
	(Get-Content $fileName) -replace "Sample",$NomeProjeto | Set-Content $fileName
	(Get-Content $fileName) -replace "Template",($NomeSolution) | Set-Content $fileName
}





