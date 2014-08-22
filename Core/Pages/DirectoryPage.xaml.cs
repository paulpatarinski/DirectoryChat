using System;
using Xamarin.Forms;

namespace Core
{
	public partial class DirectoryPage : ContentPage
	{
		public DirectoryPage ()
		{
			InitializeComponent ();
			_viewModel = new DirectoryViewModel (this.Navigation);
			BindingContext = _viewModel;
		}

		readonly DirectoryViewModel _viewModel;

		async void OnButtonClicked (object sender, EventArgs args)
		{ 
			var button = (Button)sender; 

			await _viewModel.StartChatAsync (button.CommandParameter.ToString ());
		}
	}
}