using System;

namespace TaskB
{
    class TaskB
    {
         


        static void Main(string[] args)
        {
            (double xCentre, double yCentre, double radius) circle;
            (double x, double y) point;

            Function.FillTupleCircle(out circle);
            Function.FillTuplePoint(out point);
            Function.HittingPoint(circle, point);

            (double xCentre, double yCentre, double radius) circle1;
            Function. FillTupleCircle(out circle1);
            Function.HittingCircle(circle, circle1);
            Function.CrossingCircle(circle, circle1);
        }
    }
}
