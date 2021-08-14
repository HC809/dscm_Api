using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.JsonWebTokens;

namespace DiunsaSCMInterfaceERP.Data
{
    public class ERPInterface
    {
        private WCF_ALS.Service1Client _wcf_iax;
        public ERPInterface(string apiURI)
        {
            _wcf_iax = new WCF_ALS.Service1Client(new WCF_ALS.Service1Client.EndpointConfiguration(),
                new System.ServiceModel.EndpointAddress(apiURI));
        }

        public async Task<WCF_ALS.CallAXClassMethodResponse> ExecuteMethod(string className, string methodName, object[] args){
  
            var result = await _wcf_iax.CallAXClassMethodAsync(className, methodName, args);
            return result;
        }


    }
}
