using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Methods
{
    public class BodyRevolution
    {
        public const double PI = Math.PI;
        protected double radious;

        public BodyRevolution(double radious)
        {
            this.radious = radious;
        }

        public virtual double Volume()
        {
            return PI * radious * radious;
        }
    }
}
