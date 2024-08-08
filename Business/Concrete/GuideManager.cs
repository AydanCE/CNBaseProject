using Business.Abstract;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GuideManager(IGuideDal guideDal) : IGuideService
    {
        private readonly IGuideDal _guideDal = guideDal;
        public IResult Add(Guide guide)
        {
            if (guide.FirstName.Length >= 4)
            {
                _guideDal.Add(guide);
                return new SuccessResult($"{guide.FirstName} has been added");
            }
            return new ErrorResult($"{guide.FirstName} cannot be added!");
        }
        public IResult Delete(int id)
        {
            Guide deleteGuide = null;
            Guide resultGuide = _guideDal.Get(g => g.Id == id && g.IsDelete == false);
            if (resultGuide != null)
            {
                deleteGuide = resultGuide;
                deleteGuide.IsDelete = true;
                _guideDal.Delete(deleteGuide);
                return new SuccessResult($"Guide has been deleted");
            }
            return new ErrorResult($"Guide is not found");
        }
        public IResult Update(Guide guide)
        {
            Guide updateGuide = _guideDal.Get(g => g.Id == guide.Id && g.IsDelete == false);
            if (updateGuide != null)
            {
                updateGuide.FirstName = guide.FirstName;
                updateGuide.LastName = guide.LastName;
                updateGuide.PhoneNumber = guide.PhoneNumber;
                updateGuide.Email = guide.Email;
                _guideDal.Update(updateGuide);
                return new SuccessResult($"{guide.FirstName} has been updated");
            }
            return new ErrorResult($"{guide.FirstName} is not found");
        }
        public IDataResult<List<Guide>> GetAllGuide()
        {
            var guides = _guideDal.GetAll(g => g.IsDelete == false).ToList();
            if (guides.Count != 0)
            {
                return new SuccessDataResult<List<Guide>>(guides);
            }
            return new ErrorDataResult<List<Guide>>("Error occured!");
        }
        public IDataResult<Guide> GetGuide(int id)
        {
            Guide getGuide = _guideDal.Get(g => g.Id == id && g.IsDelete == false);
            if (getGuide != null)
            {
                return new SuccessDataResult<Guide>(getGuide, $"Guide has been gotten");
            }
            return new ErrorDataResult<Guide>($"Guide is not found");
        }
        public IDataResult<List<GuideDto>> GetAllGuidesByTour(int tourId)
        {
            var result = _guideDal.GetAllGuidesByTour(tourId);
            if(result.Count > 0)
            {
                return new SuccessDataResult<List<GuideDto>>(result, "List has been downloaded");
            }
            return new ErrorDataResult<List<GuideDto>>(result, "Error occured");
        }
    }
}
