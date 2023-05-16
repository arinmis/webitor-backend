using Core.Interfaces;
using System;

namespace Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
