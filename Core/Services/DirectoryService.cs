using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core
{
	public interface IDirectoryService
	{
		Task<IEnumerable<Person>> GetPeopleAsync ();
	}

	public class DirectoryService : IDirectoryService
	{
		public async Task<IEnumerable<Person>> GetPeopleAsync ()
		{
			var people = new List<Person> () {

			};

			for (int i = 1; i <= 50; i++) {
				people.Add (new Person {
					FirstName = "Paul" + i,
					LastName = "P",
					ProfileImage = "Fireman"
				});

				people.Add (new Person {
					FirstName = "Sandesh" + i,
					LastName = "M",
					ProfileImage = "Fireman"
				});
			}

			return people;
		}
	}
}

