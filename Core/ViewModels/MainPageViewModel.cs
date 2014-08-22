using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Core
{
	public class MainPageViewModel : BaseViewModel
	{
		public MainPageViewModel () : this (new DirectoryService ())
		{
		}

		public MainPageViewModel (IDirectoryService directoryService)
		{
			_directoryService = directoryService;
			Message = "Directory";
			LoadPeopleAsync ();
		}

		readonly IDirectoryService _directoryService;

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


		public async Task LoadPeopleAsync ()
		{
			var people = await _directoryService.GetPeopleAsync ();

			foreach (var person in people) {
				People.Add (person);
			}
		}
	}
}

