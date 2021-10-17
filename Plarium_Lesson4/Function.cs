using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class Function
    {
        //5. Окружность.В сущностях(типах) хранятся координаты центра на плоскости и радиус.
        //Проверить попадание заданной точки внутрь данной окружности.
        //Проверить попадание другой окружности внутрь данной.
        //Проверить пересечение другой окружности с данной.

        //Метод заполнения значениями кортежа окружности
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

        //Метод заполнения значениями кортежа точки
        public static void FillTuplePoint(out (double x, double y) point)
        {
            Console.WriteLine("--Введите координаты точки--");
            Console.Write("\tx: ");
            point.x = double.Parse(Console.ReadLine());
            Console.Write("\ty: ");
            point.y = double.Parse(Console.ReadLine());
        }

        //Метод проверки попадания точки в окружность
        public static void HittingPoint((double xCentre, double yCentre, double radius) circle, (double x, double y) point)
        {
            if (Math.Pow((point.x - circle.xCentre), 2) + Math.Pow((point.y - circle.yCentre), 2) <= Math.Pow(circle.radius, 2))
            {
                Console.WriteLine("~Точка попадает в данную окружность~");
            }
            else Console.WriteLine("~Точка не попадает в данную окружность~");
        }

        //Метод вычисления расстояния между уентрами окружностей
        static double Distance((double xCentre, double yCentre, double radius) circle,
                                (double xCentre, double yCentre, double radius) circle1)
           => Math.Sqrt(Math.Pow((circle1.xCentre - circle.xCentre), 2) + Math.Pow((circle1.yCentre - circle.yCentre), 2));

        //Метод проверки попадания окружности в главную окружность
        public static void HittingCircle((double xCentre, double yCentre, double radius) circle,
                                (double xCentre, double yCentre, double radius) circle1)
        {
            double distance = Distance(circle, circle1);
            if (distance + circle1.radius <= circle.radius)
                Console.WriteLine("~Круг попадает в данную окружность~");
            else Console.WriteLine("~Круг не попадает в данную окружность~");
        }

        //Метод проверки пересечения окружностей
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
