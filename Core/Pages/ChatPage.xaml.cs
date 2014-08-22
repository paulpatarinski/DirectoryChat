using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Core
{
	public partial class ChatPage : ContentPage
	{
		public ChatPage (int id)
		{
			InitializeComponent ();
			BindingContext = new ChatPageViewModel ();
		}

		public void ShowMessage (string message)
		{
			var viewModel = this.BindingContext as ChatPageViewModel;

			if (viewModel != null) {
				viewModel.SubmitMessage (message);
			}

		}
	}
}

