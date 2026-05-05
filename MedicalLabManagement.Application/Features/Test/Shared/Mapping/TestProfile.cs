using AutoMapper;
using MedicalLabManagement.Application.Features.Test.Shared.Dtos;

namespace MedicalLabManagement.Application.Features.Test.Shared.Mapping
{
	public class TestProfile : Profile
	{
		public TestProfile()
		{
			MapEntity();
		}
		private void MapEntity()
		{
			CreateMap<TestModel, TestResponse>()
				.ForMember(d => d.CategoryArName, d => d.MapFrom(x => x.Category.ArName))
				.ForMember(d => d.CategoryEnName, d => d.MapFrom(x => x.Category.EnName))
				.ReverseMap();
		}
	}
}
