using Business.Abstract;
using Core.Helpers.Result.Abstract;
using Core.Helpers.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TourManager(ITourDal tourDal) : ITourService
    {
        private readonly ITourDal _tourDal = tourDal;
        public IResult Add(Tour tour)
        {
            if (tour.TourName.Length >= 4)
            {
                _tourDal.Add(tour);
                return new SuccessResult($"{tour.TourName} has been added");
            }
            return new ErrorResult($"{tour.TourName} cannot be added!");
        }
        public IResult Delete(Tour tour)
        {
            Tour deleteTour = null;
            Tour resultTour = _tourDal.Get(t => t.Id == tour.Id && t.IsDelete == false);
            if (resultTour != null)
            {
                deleteTour = resultTour;
                deleteTour.IsDelete = true;
                _tourDal.Delete(deleteTour);
                return new SuccessResult($"{tour.TourName} has been deleted");
            }
            return new ErrorResult($"{tour.TourName} is not found");
        }
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
        public IDataResult<Tour> GetTour(Tour tour)
        {
            Tour getTour = _tourDal.Get(t => t.Id == tour.Id && t.IsDelete == false);
            if (getTour != null)
            {
                return new SuccessDataResult<Tour>(getTour, $"{tour.TourName} has been gotten");
            }
            return new ErrorDataResult<Tour>($"{tour.TourName} is not found");
        }
    }
}
