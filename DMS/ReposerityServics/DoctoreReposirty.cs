using AutoMapper;
using DMS.ApplicationDbContext;
using DMS.Models;
using DMS.Servics;
using DMS.viewModel;

namespace DMS.ReposerityServics
{
    public class DoctoreReposirty : RepositoryService<Doctor, DoctorVM>,IDoctoreRepository
    {
        public DoctoreReposirty(IMapper mapper, DocterDb docterDb) : base(mapper, docterDb)
        {
        }
    }
}
