// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// The Compute Management Client.
    /// </summary>
    public partial interface IComputeManagementClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// The management credentials for Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// Gets subscription credentials which uniquely identify Microsoft
        /// Azure subscription. The subscription ID forms part of the URI for
        /// every service call.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Client Api Version.
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        /// <summary>
        /// The retry timeout for Long Running Operations.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }


        IAvailabilitySetsOperations AvailabilitySets { get; }

        IVirtualMachineExtensionImagesOperations VirtualMachineExtensionImages { get; }

        IVirtualMachineExtensionsOperations VirtualMachineExtensions { get; }

        IVirtualMachineImagesOperations VirtualMachineImages { get; }

        IUsageOperations Usage { get; }

        IVirtualMachineSizesOperations VirtualMachineSizes { get; }

        IVirtualMachinesOperations VirtualMachines { get; }

        IVirtualMachineScaleSetsOperations VirtualMachineScaleSets { get; }

        IVirtualMachineScaleSetVMsOperations VirtualMachineScaleSetVMs { get; }

    }
}
