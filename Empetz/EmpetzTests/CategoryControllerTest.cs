using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmpetzTests
{
	public class CategoryControllerTest
	{
		protected readonly HttpClient _httpClient;

		public CategoryControllerTest(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		[Fact]
		public async Task Get_All_Categories_Result_Success()
		{
				//Arrange  
				//Act
				var response = await _httpClient.GetAsync("/Categories");

				//Assert
				Assert.Equal(HttpStatusCode.OK, response.StatusCode);

		}
		[Fact]
		public async Task Get_Breeds_with_ValidCategoryId_returnSuccess()
		{
		
				//Arrange  
				var categoryid = "3fa85f64-5717-4562-b3fc-2c963f66afa6";


				//Act
				var response = await _httpClient.GetAsync("Categories/{categoryid}/Breeds");
				//Assert
				Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			
		}
		[Fact]
		public async Task Get_Breeds_with_EmptyCategoryId_returnBadRequest()
		{

		
			var categoryid = Guid.Empty;


			//Act
			var response = await _httpClient.GetAsync("Categories/{categoryid}/Breeds");
			//Assert
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


		}
		[Fact]
		public async Task Get_Breeds_with_InValidCategoryId_returnsNocontent()
		{


			var categoryid = "3fa85f64-5717-4562-b3fc-2c963f66afa3";
			//Act
			var response = await _httpClient.GetAsync("Categories/{categoryid}/Breeds");
			//Assert
			Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);


		}

	}
}

