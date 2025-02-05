﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OWSData.Models.Composites;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using OWSShared.Messages;
using OWSShared.Options;
using RabbitMQ.Client;

namespace OWSInstanceManagement.Requests.Instance
{
    public class ShutDownServerInstanceRequest : IRequestHandler<SpinUpServerInstanceRequest, IActionResult>, IRequest
    {
        public int WorldServerID { get; set; }
        public int ZoneInstanceID { get; set; }

        private IOptions<RabbitMQOptions> _rabbitMQOptions;
        private SuccessAndErrorMessage Output;
        private Guid CustomerGUID;
        private IInstanceManagementRepository _instanceMangementRepository;

        public void SetData(IOptions<RabbitMQOptions> rabbitMQOptions, IInstanceManagementRepository instanceMangementRepository, IHeaderCustomerGUID customerGuid)
        {
            _rabbitMQOptions = rabbitMQOptions;
            _instanceMangementRepository = instanceMangementRepository;
            CustomerGUID = customerGuid.CustomerGUID;
        }

        public async Task<IActionResult> Handle()
        {
            //Set the ZoneInstance status to shutting down


            //Send the servershutdown message to RabbitMQ
            ConnectionFactory factory = new()
            {
                HostName = _rabbitMQOptions.Value.RabbitMQHostName,
                Port = _rabbitMQOptions.Value.RabbitMQPort,
                UserName = _rabbitMQOptions.Value.RabbitMQUserName,
                Password = _rabbitMQOptions.Value.RabbitMQPassword
            };

            using (var connection = await factory.CreateConnectionAsync())
            {
                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.ExchangeDeclareAsync(exchange: "ows.servershutdown",
                        type: "direct",
                        durable: false,
                        autoDelete: false);

                    MQShutDownServerMessage serverSpinUpMessage = new() 
                    {
                        CustomerGUID = CustomerGUID,
                        ZoneInstanceID = ZoneInstanceID
                    };
                    
                    var body = serverSpinUpMessage.Serialize();

                    await channel.BasicPublishAsync(exchange: "ows.servershutdown",
                                         routingKey: String.Format("ows.servershutdown.{0}", WorldServerID),
                                         body: body);
                }
            }

            Output = new SuccessAndErrorMessage()
            {
                Success = true,
                ErrorMessage = ""
            };

            return new OkObjectResult(Output);
        }
    }
}
