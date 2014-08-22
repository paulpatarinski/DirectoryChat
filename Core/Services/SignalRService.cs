using System;
using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;

namespace Core
{
	public class SignalRService
	{
		public SignalRService ()
		{
		}

		HubConnection _hubConnection {
			get;
			set;
		}

		IHubProxy _chatHubProxy {
			get;
			set;
		}

		public async Task Connect ()
		{
			// Connect to the server
			_hubConnection = new HubConnection ("http://xamarinsignalr.azurewebsites.net/");

			// Create a proxy to the 'ChatHub' SignalR Hub
			_chatHubProxy = _hubConnection.CreateHubProxy ("ChatHub");

			await _hubConnection.Start ();
		}

		public void OnMessageReceive (Action<string,string> messageReceivedAction)
		{
			_chatHubProxy.On<string, string> ("broadcastMessage", messageReceivedAction);
		}

		public async Task SendMessageAsync (string message)
		{
			var messageObj = new SignalRMessage{ Name = "Android", Message = message };
			// Invoke the 'UpdateNick' method on the server
			await _chatHubProxy.Invoke ("Send", messageObj);
		}
	}
}