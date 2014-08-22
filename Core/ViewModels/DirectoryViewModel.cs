using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Core
{
	public class DirectoryViewModel : BaseViewModel
	{
		public DirectoryViewModel (INavigation navigation) : this (new DirectoryService (), navigation)
		{
		}

		public DirectoryViewModel (IDirectoryService directoryService, INavigation navigation)
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

		public async Task StartChatAsync (string name)
		{
			_navigation.PushAsync (new ChatPage (name));
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

