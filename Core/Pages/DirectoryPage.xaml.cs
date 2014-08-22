using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

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
			var button = (Button)sender; 

			await _viewModel.StartChatAsync (Convert.ToInt32 (button.CommandParameter));
		}
	}
}