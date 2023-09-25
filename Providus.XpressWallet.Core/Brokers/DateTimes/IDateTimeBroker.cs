using System;

namespace Providus.XpressWallet.Core.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds);
    }
}
