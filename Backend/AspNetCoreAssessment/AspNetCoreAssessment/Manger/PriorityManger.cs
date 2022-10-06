using AspNetCoreAssessment.Entities;
using AspNetCoreAssessment.Reposatory;

namespace AspNetCoreAssessment.Manger
{
    public class PriorityManger
    {
        private readonly BaseRepo<Priorities> PrioritiesRepo;
        public PriorityManger(AspnetcoreassessmentContext DbCotext)
        {
            PrioritiesRepo= new BaseRepo<Priorities>(DbCotext);
        }
        public IQueryable<Priorities> GetAllPriorities()
        {
            return PrioritiesRepo.GetAll();
        }
        public Priorities SearchPriority(int id)
        {
            return PrioritiesRepo.Get(id);
        }
    }
}
