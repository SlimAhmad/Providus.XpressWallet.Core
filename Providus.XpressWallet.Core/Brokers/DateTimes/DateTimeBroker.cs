using System;

namespace Providus.XpressWallet.Core.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset ConvertToDateTimeOffSet(int totalSeconds) =>
            DateTimeOffset.FromUnixTimeSeconds(totalSeconds);
    }
}
