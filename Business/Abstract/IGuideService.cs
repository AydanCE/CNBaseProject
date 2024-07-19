using Core.Helpers.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGuideService
    {
        IResult Add(Guide guide);
        IResult Update(Guide guide);
        IResult Delete(Guide guide);
        IDataResult<List<Guide>> GetAllGuide();
        IDataResult<Guide> GetGuide(Guide guide);
    }
}
