using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class GuideDto : IDto
    {
        public string GuideName { get; set; }
        public int Experiences { get; set; }
        public string TourName { get; set; }
        public int TourId { get; set; }
        public int GuideId { get; set; }
    }
}
