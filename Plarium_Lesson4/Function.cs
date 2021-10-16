using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class Function
    {
        public static void FillTupleCircle(out (double xCentre, double yCentre, double radius) circle)
        {
            Console.WriteLine("--Введите координаты центра окружности--");
            Console.Write("\tx: ");
            circle.xCentre = double.Parse(Console.ReadLine());
            Console.Write("\ty: ");
            circle.yCentre = double.Parse(Console.ReadLine());
            Console.Write("--Введите радиус окружности: ");
            circle.radius = double.Parse(Console.ReadLine());
        }
        public static void FillTuplePoint(out (double x, double y) point)
        {
            Console.WriteLine("--Введите координаты точки--");
            Console.Write("\tx: ");
            point.x = double.Parse(Console.ReadLine());
            Console.Write("\ty: ");
            point.y = double.Parse(Console.ReadLine());
        }
        public static void HittingPoint((double xCentre, double yCentre, double radius) circle, (double x, double y) point)
        {
            if (Math.Pow((point.x - circle.xCentre), 2) + Math.Pow((point.y - circle.yCentre), 2) <= Math.Pow(circle.radius, 2))
            {
                Console.WriteLine("~Точка попадает в данную окружность~");
            }
            else Console.WriteLine("~Точка не попадает в данную окружность~");
        }

        static double Distance((double xCentre, double yCentre, double radius) circle,
                                (double xCentre, double yCentre, double radius) circle1)
           => Math.Sqrt(Math.Pow((circle1.xCentre - circle.xCentre), 2) + Math.Pow((circle1.yCentre - circle.yCentre), 2));


        public  static void HittingCircle((double xCentre, double yCentre, double radius) circle,
                                (double xCentre, double yCentre, double radius) circle1)
        {
            double distance = Distance(circle, circle1);
            if (distance + circle1.radius <= circle.radius)
                Console.WriteLine("~Круг попадает в данную окружность~");
            else Console.WriteLine("~Круг не попадает в данную окружность~");
        }

        public static void CrossingCircle((double xCentre, double yCentre, double radius) circle,
                                (double xCentre, double yCentre, double radius) circle1)
        {
            double distance = Distance(circle, circle1);
            if (distance != 0 &&
                distance >= Math.Abs(circle.radius - circle1.radius))
            {
                Console.WriteLine("~Круг пересекает данную окружность~");
            }
            else Console.WriteLine("~Круг не пересекает данную окружность~");
        }
    }
}
