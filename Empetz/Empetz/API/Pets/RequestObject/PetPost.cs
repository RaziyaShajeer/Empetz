namespace Empetz.API.Pets.RequestObject
{
	public class PetPost
	{
		public PetPost()
		{
		}

		public PetPost(string name, Guid breedid, int age, string discription, string gender, Guid petsCategoryId, string? image, Guid userId)
		{
			Name = name;
			Breedid = breedid;
			Age = age;
			Discription = discription;
			Gender = gender;
			PetsCategoryId = petsCategoryId;
			Image = image;
			UserId = userId;
		}

		public string Name { get; set; }
		public Guid Breedid { get; set; }
		public int Age { get; set; }
		public string Discription { get; set; }
		public string Gender { get; set; }
		public Guid PetsCategoryId { get; set; }
		public string? Image { get; set; }
		public Guid UserId { get; set; }


	}
}
