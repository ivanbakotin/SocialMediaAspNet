using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Repositories.VotedRepositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
