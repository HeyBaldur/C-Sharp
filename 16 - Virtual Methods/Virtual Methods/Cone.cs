using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Methods
{
    public class Cone : BodyRevolution
    {
        private double height;
        public Cone(double radious, double height) : base(radious)
        {
            this.height = height;
        }

        public override double Volume()
        {
            var result = (0.3333333333) * base.Volume() * height;
            return result;
        }
    }
}
