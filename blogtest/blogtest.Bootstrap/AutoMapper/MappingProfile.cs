using AutoMapper;
using blogtest.Common.Dtos;
using blogtest.DAL.Entities;

namespace blogtest.Bootstrap.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            EntityToDto();
            DtoToEntity();
        }


        private void EntityToDto()
        {
            CreateMap<PostDto, Post>();
            CreateMap<CommentDto, Comment>();

        }

        private void DtoToEntity()
        {
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();

        }
    }
}
