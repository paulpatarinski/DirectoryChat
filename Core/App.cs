using System;
using Xamarin.Forms;

namespace Core
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			var navigationPage = new NavigationPage (new DirectoryPage ());
			navigationPage.SetValue (NavigationPage.HasNavigationBarProperty, false);
			return navigationPage;
		}
	}
}

