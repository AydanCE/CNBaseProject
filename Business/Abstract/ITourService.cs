using Core.Helpers.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITourService
    {
        IResult Add(Tour tour);
        IResult Update(Tour tour);
        IResult Delete(Tour tour);
        IDataResult<List<Tour>> GetAllTour();
        IDataResult<Tour> GetTour(Tour tour);
    }
}
