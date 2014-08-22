using System;
using System.Collections.Generic;
using Xamarin.Forms;

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

		ChatPageViewModel _viewModel;

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			_viewModel.ConnectAsync ();
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

