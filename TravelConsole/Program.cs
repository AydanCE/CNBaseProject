using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;

//Tour tour2 = new() { TourName = "Quba", Description = "15 people", TourPrice = 90, IsDiscount = false, DiscountRate = 0};

//TourManager tourManager = new TourManager(new EfTourDal());

////tourManager.Add(tour2);

//var allTours = tourManager.GetAllTour();
//foreach(var tour in allTours.Data)
//{
//    Console.WriteLine(tour.TourName);
//}

//foreach (var tour in allTours.Data)
//{
//    if(tour.Id == 1)
//    {
//       var newTour = tourManager.GetTour(tour).Data;
//        Console.WriteLine(newTour.Description);
//    }
//}

//foreach (var tour in allTours.Data)
//{
//    if (tour.Id == 7)
//    {
//        tour.TourName = "Qusar";
//        tourManager.Update(tour);
//    }
//}