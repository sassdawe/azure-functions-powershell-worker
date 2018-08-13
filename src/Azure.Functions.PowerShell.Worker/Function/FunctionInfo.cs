using Google.Protobuf.Collections;
using Microsoft.Azure.WebJobs.Script.Grpc.Messages;
using Microsoft.Azure.Functions.PowerShellWorker.Utility;

namespace Microsoft.Azure.Functions.PowerShellWorker
{
    public class FunctionInfo
    {
        public string Name {get; private set;}
        public string Directory {get; private set;}
        public MapField<string, BindingInfo> Bindings {get; private set;}
        public MapField<string, BindingInfo> OutputBindings {get; private set;}
        public string HttpOutputName {get; private set;}

        public FunctionInfo(RpcFunctionMetadata metadata)
        {
            Name = metadata.Name;
            Directory = metadata.Directory;
            Bindings = new MapField<string, BindingInfo>();
            OutputBindings = new MapField<string, BindingInfo>();
            HttpOutputName = "";

            foreach (var binding in metadata.Bindings)
            {
                Bindings.Add(binding.Key, binding.Value);

                if (binding.Value.Direction != BindingInfo.Types.Direction.In)
                {
                    if(binding.Value.Type == "http")
                    {
                        HttpOutputName = binding.Key;
                    }if(binding.Value.Type == "http")
                    {
                        HttpOutputName = binding.Key;
                    }
                    OutputBindings.Add(binding.Key, binding.Value);
                }
            }
        }
    }
}