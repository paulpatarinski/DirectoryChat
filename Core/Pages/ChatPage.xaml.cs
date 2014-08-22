using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Core
{
	public partial class ChatPage : ContentPage
	{
		public ChatPage (string name)
		{
			InitializeComponent ();
			_viewModel = new ChatPageViewModel (name, Navigation);
			BindingContext = _viewModel;
			_name = name;
		}

		string _name;
		bool _chatConnected;

		ChatPageViewModel _viewModel;


		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (!_chatConnected) {
				_viewModel.ConnectAsync ();
				_chatConnected = true;
			}
		}

		public void ShowMessage (string message)
		{
			var viewModel = this.BindingContext as ChatPageViewModel;

			if (viewModel != null) {
				viewModel.SubmitMessage (_name, message);
			}

		}
	}
}

