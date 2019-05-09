// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.CustomProviders.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Error definition.
    /// </summary>
    public partial class ErrorDefinition
    {
        /// <summary>
        /// Initializes a new instance of the ErrorDefinition class.
        /// </summary>
        public ErrorDefinition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ErrorDefinition class.
        /// </summary>
        /// <param name="code">Service specific error code which serves as the
        /// substatus for the HTTP error code.</param>
        /// <param name="message">Description of the error.</param>
        /// <param name="details">Internal error details.</param>
        public ErrorDefinition(string code = default(string), string message = default(string), IList<ErrorDefinition> details = default(IList<ErrorDefinition>))
        {
            Code = code;
            Message = message;
            Details = details;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets service specific error code which serves as the substatus for
        /// the HTTP error code.
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; private set; }

        /// <summary>
        /// Gets description of the error.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; private set; }

        /// <summary>
        /// Gets internal error details.
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public IList<ErrorDefinition> Details { get; private set; }

    }
}