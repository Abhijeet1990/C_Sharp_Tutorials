﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalculatorWebApp.CalculatorService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://abhijeetsahu.org/", ConfigurationName="CalculatorService.CalculatorWebServicesSoap")]
    public interface CalculatorWebServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Add", ReplyAction="*")]
        int Add(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Add", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AddAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Substract", ReplyAction="*")]
        int Substract(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Substract", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SubstractAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Multiply", ReplyAction="*")]
        int Multiply(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Multiply", ReplyAction="*")]
        System.Threading.Tasks.Task<int> MultiplyAsync(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Divide", ReplyAction="*")]
        int Divide(int a, int b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://abhijeetsahu.org/Divide", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DivideAsync(int a, int b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CalculatorWebServicesSoapChannel : CalculatorWebApp.CalculatorService.CalculatorWebServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorWebServicesSoapClient : System.ServiceModel.ClientBase<CalculatorWebApp.CalculatorService.CalculatorWebServicesSoap>, CalculatorWebApp.CalculatorService.CalculatorWebServicesSoap {
        
        public CalculatorWebServicesSoapClient() {
        }
        
        public CalculatorWebServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorWebServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorWebServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorWebServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int a, int b) {
            return base.Channel.Add(a, b);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int a, int b) {
            return base.Channel.AddAsync(a, b);
        }
        
        public int Substract(int a, int b) {
            return base.Channel.Substract(a, b);
        }
        
        public System.Threading.Tasks.Task<int> SubstractAsync(int a, int b) {
            return base.Channel.SubstractAsync(a, b);
        }
        
        public int Multiply(int a, int b) {
            return base.Channel.Multiply(a, b);
        }
        
        public System.Threading.Tasks.Task<int> MultiplyAsync(int a, int b) {
            return base.Channel.MultiplyAsync(a, b);
        }
        
        public int Divide(int a, int b) {
            return base.Channel.Divide(a, b);
        }
        
        public System.Threading.Tasks.Task<int> DivideAsync(int a, int b) {
            return base.Channel.DivideAsync(a, b);
        }
    }
}
