using System;

namespace GFEditor.Enums
{
    public enum TimeLimitTypeEnum
    {
        None = 0,
        RealMin = 60, // 1 Real Minute Value
        RealHour = 3600, // 1 Real Hour Value
        RealDays = 86400 // 1 Real Day Value
    }

    [Flags]
    public enum TimeTypeEnum
    {
        None = 0,
        Sec = 1,
        Min = 2,
        RealHour = 3,
        RealDays = 4,
        NoDurationNoSave = 5,
        RealMin = 6
    }
}
