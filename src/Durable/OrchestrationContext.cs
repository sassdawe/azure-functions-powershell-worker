//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
//

#pragma warning disable 1591 // Missing XML comment for publicly visible type or member 'member'

namespace Microsoft.Azure.Functions.PowerShellWorker.Durable
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Threading;

    /// <summary>
    /// Represent the context of an execution of an orchestration function.
    /// </summary>
    [DataContract]
    public class OrchestrationContext
    {
        [DataMember]
        public object Input { get; internal set; }

        [DataMember]
        internal string InstanceId { get; set; }

        [DataMember]
        internal string ParentInstanceId { get; set; }

        [DataMember]
        internal bool IsReplaying { get; set; }

        [DataMember]
        internal HistoryEvent[] History { get; set; }

        internal AutoResetEvent ActionEvent { get; set; }

        internal List<List<OrchestrationAction>> Actions { get; } = new List<List<OrchestrationAction>>();
    }
}
