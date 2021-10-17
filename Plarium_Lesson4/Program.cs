using System;

namespace TaskB
{
    class Program
    {  
        static void Main(string[] args)
        {
            //Создание кортежа для окружности главной
            (double xCentre, double yCentre, double radius) circle;
            //Создание кортежа для точки
            (double x, double y) point;

            //Заполнение значениями кортежа окружности
            Function.FillTupleCircle(out circle);
            //Заполнение значениями кортежа точки
            Function.FillTuplePoint(out point);
            //Вызов метода проверки попадания точки в окружность
            Function.HittingPoint(circle, point);

            //Создание кортежа для второй окружности
            (double xCentre, double yCentre, double radius) circle1;
            //Заполнение значениями кортежа окружности
            Function. FillTupleCircle(out circle1);
            //Вызов метода проверки попадания окружности в главную окружность
            Function.HittingCircle(circle, circle1);
            //Вызов метода проверки пересечения окружностей
            Function.CrossingCircle(circle, circle1);
        }
    }
}
