using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Core
{
	public class ChatPageViewModel: BaseViewModel
	{
		//TODO : Use IOC
		public ChatPageViewModel (string name, INavigation navigation) : this (new SignalRService (), name, navigation)
		{
		}

		public ChatPageViewModel (SignalRService signalRService, string name, INavigation navigation)
		{
			_signalRService = signalRService;
			_name = name;
			_navigation = navigation;

			SubmitButtonCommand = new Command (() => {
				SubmitMessage (name, Message);
			});

		}

		readonly SignalRService _signalRService;

		string _name;

		string _message;

		INavigation _navigation;

		public string Message{ get { return _message; } set { ChangeAndNotify (ref _message, value); } }

		ObservableCollection<SignalRMessage> _messages;

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
			await _navigation.PushAsync (new ContentPage () {Title = "Chat", Content = new Label {
					Text = "Connecting to chat...",
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					Font = Font.SystemFontOfSize (20)
				}
			});

			await _signalRService.Connect ();

			await _navigation.PopAsync ();

			_signalRService.OnMessageReceive ((name, message) => {
				var messageObj = new SignalRMessage { Name = name, Message = message };
				Messages.Add (messageObj);
			});
		}

		public ICommand SubmitButtonCommand { protected set; get; }

		public async Task SubmitMessage (string name, string message)
		{
			_signalRService.SendMessageAsync (name, message);

			Message = string.Empty;
		}
	}
}

