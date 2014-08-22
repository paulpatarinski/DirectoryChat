using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Core
{
	public class MainPageViewModel : BaseViewModel
	{
		public MainPageViewModel (INavigation navigation) : this (new DirectoryService (), navigation)
		{
		}

		public MainPageViewModel (IDirectoryService directoryService, INavigation navigation)
		{
			_directoryService = directoryService;
			_navigation = navigation;
			Message = "Directory";
		
			LoadPeopleAsync ();
		}

		readonly IDirectoryService _directoryService;
		readonly INavigation _navigation;

		string _message;

		public string Message{ get { return _message; } set { ChangeAndNotify (ref _message, value); } }



		ObservableCollection<Person> _people;

		public ObservableCollection<Person> People {
			get {
				if (_people == null)
					_people = new ObservableCollection<Person> ();
				return _people;
			}
			set { ChangeAndNotify (ref _people, value); }
		}

		public async Task StartChatAsync (int id)
		{
			_navigation.PushAsync (new ChatPage (id));
		}

		public async Task LoadPeopleAsync ()
		{
			var people = await _directoryService.GetPeopleAsync ();

			foreach (var person in people) {
				People.Add (person);
			}
		}
	}
}

