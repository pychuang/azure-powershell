﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, "AzureRmVirtualNetworkSubnetConfig", DefaultParameterSetName = "SetByResource"), OutputType(typeof(PSVirtualNetwork))]
    public class AddAzureVirtualNetworkSubnetConfigCommand : AzureVirtualNetworkSubnetConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            // Verify if the subnet exists in the VirtualNetwork
            var subnet = this.VirtualNetwork.Subnets.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (subnet != null)
            {
                throw new ArgumentException("Subnet with the specified name already exists");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.NetworkSecurityGroup != null)
                {
                    this.NetworkSecurityGroupId = this.NetworkSecurityGroup.Id;
                }

                if (this.RouteTable != null)
                {
                    this.RouteTableId = this.RouteTable.Id;
                }
            }

            subnet = new PSSubnet();

            subnet.Name = this.Name;
            subnet.AddressPrefix = this.AddressPrefix;
            
            if (!string.IsNullOrEmpty(this.NetworkSecurityGroupId))
            {
                subnet.NetworkSecurityGroup = new PSNetworkSecurityGroup();
                subnet.NetworkSecurityGroup.Id = this.NetworkSecurityGroupId;
            }

            if (!string.IsNullOrEmpty(this.RouteTableId))
            {
                subnet.RouteTable = new PSRouteTable();
                subnet.RouteTable.Id = this.RouteTableId;
            }

            this.VirtualNetwork.Subnets.Add(subnet);

            WriteObject(this.VirtualNetwork);
        }
    }
}
