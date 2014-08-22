using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Core
{
	public partial class DirectoryPage : ContentPage
	{
		public DirectoryPage ()
		{
			InitializeComponent ();
			_viewModel = new MainPageViewModel (this.Navigation);
			BindingContext = _viewModel;
		}

		MainPageViewModel _viewModel;

		async void OnButtonClicked (object sender, EventArgs args)
		{ 
			Button button = (Button)sender; 

			_viewModel.StartChatAsync ((int)button.CommandParameter);

		}
	}
}

