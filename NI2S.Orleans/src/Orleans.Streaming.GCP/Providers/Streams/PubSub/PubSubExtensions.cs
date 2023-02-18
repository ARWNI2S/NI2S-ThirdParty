using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.PubSub.V1;

namespace Orleans.Providers.GCP.Streams.PubSub
{
    internal static class PubSubExtensions
    {
        //TODO: UPGRADE AND GET IT TO WORK
        public static async Task PublishAsync(this PublisherClient publisher, TopicName topicName, IEnumerable<PubsubMessage> messages)
        {
            foreach (var message in messages)
            {
                await publisher?.PublishAsync(message);
            }
        }

        //TODO: UPGRADE AND GET IT TO WORK
        public static async Task<Subscription> CreateSubscriptionAsync(this SubscriberClient subscriber, SubscriptionName subscriptionName, TopicName topicName, PushConfig pushConfig, int ackDeadlineSeconds)
        {
            await Task.FromException(new NotImplementedException());
            throw new NotImplementedException();
        }

        //TODO: UPGRADE AND GET IT TO WORK
        public static async Task<PullResponse> PullAsync(this SubscriberClient subscriber, SubscriptionName subscriptionName, bool unknown, int messageSize)
        {
            await Task.FromException(new NotImplementedException());
            throw new NotImplementedException();
        }

        //TODO: UPGRADE AND GET IT TO WORK
        public static async Task AcknowledgeAsync(this SubscriberClient subscriber, SubscriptionName subscriptionName, IEnumerable<string> messages)
        {
            await Task.FromException(new NotImplementedException());
            throw new NotImplementedException();
        }
    }
}

