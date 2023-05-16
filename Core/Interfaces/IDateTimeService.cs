using System;

namespace Core.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
