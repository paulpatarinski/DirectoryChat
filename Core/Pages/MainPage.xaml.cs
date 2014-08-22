using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Core
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
			_viewModel = new MainPageViewModel (this.Navigation);
			BindingContext = _viewModel;
		}


		MainPageViewModel _viewModel;

		async void OnButtonClicked (object sender, EventArgs args)
		{ 
			Button button = (Button)sender; 

			_viewModel.StartChat ((int)button.CommandParameter);

		}

	}
}

