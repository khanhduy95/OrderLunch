using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Application.Commands
{
    [DataContract]
    public class SetPaidOrderStatusCommand : IRequest<bool>
    {

        [DataMember]
        public int OrderNumber { get; private set; }
        public SetPaidOrderStatusCommand(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
