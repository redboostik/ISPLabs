using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Task1
{
    public interface IRace : IComparable<IRace>
    {
        double speed { get; }
        double AverageSpeed(int skill);
    }
}
