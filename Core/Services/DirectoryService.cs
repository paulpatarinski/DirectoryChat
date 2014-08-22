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

				if (i % 2 == 0)
					people.Add (new Person {
						Id = i,
						FirstName = "Jane",
						LastName = "Doe",
						ProfileImage = "Fireman"
					});
				else
					people.Add (new Person {
						Id = i,
						FirstName = "John",
						LastName = "Doe",
						ProfileImage = "Fireman"
					});

			}

			return people;
		}
	}
}

