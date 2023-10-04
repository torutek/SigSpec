using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace HelloSignalR
{
    public struct ChatStruct
    {
        public string Message;
        public bool SendToAll;
    }

    public class ChatHub : Hub<IChatClient>
    {
        public Task Send(string message)
        {
            if (message == string.Empty)
            {
                return Clients.All.Welcome();
            }

            return Clients.All.Send(message);
        }

        public Task AddPerson(Person person)
        {
            return Task.CompletedTask;
        }

        public ChannelReader<Event> GetEvents()
        {
            var channel = Channel.CreateUnbounded<Event>();
            // TODO: Write events
            return channel.Reader;
        }

        public Task SendOptional(string? optionalMessage)
        {
            if (optionalMessage == null)
            {
                return Clients.All.Welcome();
            }

            return Clients.All.Send(optionalMessage);
        }

        public Task SendNullableStruct(Nullable<ChatStruct> chatStruct)
        {
            if (chatStruct.HasValue)
            {
                if (chatStruct.Value.SendToAll)
                {
                    return Clients.All.Send(chatStruct.Value.Message);
                }
            }

            return Task.CompletedTask;
        }

        public Task SendNullableGuid(Guid? guid)
        {
            return Task.CompletedTask;
        }
    }

    public class Event
    {
        public string? Type { get; set; }
    }

    public class Person
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }
    }

    public interface IChatClient
    {
        Task Welcome();

        Task Send(string message);
    }
}