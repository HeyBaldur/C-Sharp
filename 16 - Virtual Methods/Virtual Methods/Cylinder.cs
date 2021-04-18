using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_Methods
{
    public class Cylinder : BodyRevolution
    {
        private double height;
        public Cylinder(double height, double radious): base(radious)
        {
            this.height = height;
        }

        public override double Volume()
        {
            return base.Volume() * height;
        }
    }
}
