﻿using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Core
{
	public class ChatPageViewModel: BaseViewModel
	{
		//TODO : Use IOC
		public ChatPageViewModel () : this (new SignalRService ())
		{
		}

		public ChatPageViewModel (SignalRService signalRService)
		{
			_signalRService = signalRService;
			ConnectAsync ();
			SubmitButtonCommand = new Command (() => {
				SubmitMessage (Message);
			});

		}

		private readonly SignalRService _signalRService;

		string _message;

		public string Message{ get { return _message; } set { ChangeAndNotify (ref _message, value); } }

		private ObservableCollection<SignalRMessage> _messages;

		public ObservableCollection<SignalRMessage> Messages {
			get {
				if (_messages == null)
					_messages = new ObservableCollection<SignalRMessage> ();

				return _messages;
			}
			set { ChangeAndNotify (ref _messages, value); }
		}

		public async Task ConnectAsync ()
		{
			await _signalRService.Connect ();

			_signalRService.OnMessageReceive ((name, message) => {
				var messageObj = new SignalRMessage { Name = name, Message = message };
				Messages.Add (messageObj);
			});
		}

		public ICommand SubmitButtonCommand { protected set; get; }

		public async Task SubmitMessage (string message)
		{
			_signalRService.SendMessageAsync (message);

			Message = string.Empty;
		}
	}
}

