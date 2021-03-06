<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.

Code generated by Microsoft (R) PSSwagger
Changes may cause incorrect behavior and will be lost if the code is regenerated.
#>

<#
.SYNOPSIS
    Operating system disk.

.DESCRIPTION
    Operating system disk.

.PARAMETER OsType
    Operating system type.

.PARAMETER Uri
    Location of the disk.

#>
function New-OsDiskObject
{
    param(    
        [Parameter(Mandatory = $false)]
        [Microsoft.AzureStack.Management.Compute.Admin.Models.OsType]
        $OsType,
    
        [Parameter(Mandatory = $false)]
        [string]
        $Uri
    )
    
    $Object = New-Object -TypeName Microsoft.AzureStack.Management.Compute.Admin.Models.OsDisk

    $PSBoundParameters.GetEnumerator() | ForEach-Object { 
        if(Get-Member -InputObject $Object -Name $_.Key -MemberType Property)
        {
            $Object.$($_.Key) = $_.Value
        }
    }

    if(Get-Member -InputObject $Object -Name Validate -MemberType Method)
    {
        $Object.Validate()
    }

    return $Object
}

