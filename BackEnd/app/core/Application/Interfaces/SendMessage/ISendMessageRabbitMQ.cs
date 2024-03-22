using Domain.Common;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.SendMessage
{
    public interface ISendMessageRabbitMQ
    {
        void SendMessage<T>(T message);
    }
}
