using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfGuideDal : BaseRepository<Guide, BaseProjectContext>, IGuideDal
    {
        public EfGuideDal(BaseProjectContext context) : base(context) 
        {

        }
        public List<GuideDto> GetAllGuidesByTour(int tourId)
        {
            var context = new BaseProjectContext();
            var result = from g in context.Guides
                         where g.IsDelete == false && g.TourId == tourId
                         join t in context.Tours
                         on g.TourId equals t.Id
                         select new GuideDto
                         {
                             GuideId = g.Id,
                             TourId = t.Id,
                             TourName = t.TourName,
                             Experiences = g.Experiences,
                             GuideName = g.FirstName + " " + g.LastName
                         };
            return result.ToList();
        }
    }
}
