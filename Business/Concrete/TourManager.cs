using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.CrossCuttingConcern.Validation.FluentValidation;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class TourManager(ITourDal tourDal) : ITourService
    {
        private readonly ITourDal _tourDal = tourDal;
        [ValidationAspect<Tour>(typeof(TourValidator))]
        public IResult Add(Tour tour)
        {           
            _tourDal.Add(tour);
            return new SuccessResult($"{tour.TourName} has been added");           
        }
        public IResult Delete(int id)
        {
            Tour deleteTour = null;
            Tour resultTour = _tourDal.Get(t => t.Id == id && t.IsDelete == false);
            if (resultTour != null)
            {
                deleteTour = resultTour;
                deleteTour.IsDelete = true;
                _tourDal.Delete(deleteTour);
                return new SuccessResult($"tour has been deleted");
            }
            return new ErrorResult($"tour is not found");
        }
        [ValidationAspect<Tour>(typeof(TourValidator))]
        public IResult Update(Tour tour)
        {
            Tour updateTour = _tourDal.Get(t => t.Id == tour.Id && t.IsDelete == false);
            if (updateTour != null)
            {
                updateTour.TourName = tour.TourName;
                updateTour.Description = tour.Description;
                updateTour.TourPrice = tour.TourPrice;
                updateTour.IsDiscount = tour.IsDiscount;
                updateTour.DiscountRate = tour.DiscountRate;
                _tourDal.Update(updateTour);
                return new SuccessResult($"{tour.TourName} has been updated");
            }
            return new ErrorResult($"{tour.TourName} is not found");
        }
        public IDataResult<List<Tour>> GetAllTour()
        {
            var tours = _tourDal.GetAll(t => t.IsDelete == false).ToList();
            if (tours.Count != 0)
            {
                return new SuccessDataResult<List<Tour>>(tours);
            }
            return new ErrorDataResult<List<Tour>>("Error occured!");
        }
        public IDataResult<Tour> GetTour(int id)
        {
            Tour getTour = _tourDal.Get(t => t.Id == id && t.IsDelete == false);
            if (getTour != null)
            {
                return new SuccessDataResult<Tour>(getTour, $"tour has been gotten");
            }
            return new ErrorDataResult<Tour>($"tour is not found");
        }
    }
}
