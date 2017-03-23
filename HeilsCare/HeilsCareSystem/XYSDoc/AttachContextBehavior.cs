using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace XYS.Remp.Screening
{
    public class AttachContextBehavior : BehaviorExtensionElement, IEndpointBehavior
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(AttachContextBehavior);
            }
        }

        protected override object CreateBehavior()
        {
            return new AttachContextBehavior();
        }

        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint,
            System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,
            System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new IdentityHeaderInspector());
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,
            System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint endpoint)
        {
            return;
        }

        #endregion

        private class IdentityHeaderInspector : IClientMessageInspector
        {
            #region IClientMessageInspector Members

            public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
            }

            public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
            {

                MessageHeader<string> header = new MessageHeader<string>("adminxys");
                request.Headers.Add(header.GetUntypedHeader("UserName", "http://e24health.com/username"));

                header = new MessageHeader<string>("szxys.123");
                request.Headers.Add(header.GetUntypedHeader("Password", "http://e24health.com/password"));
                return null;
            }

            #endregion

        }
    }
}
