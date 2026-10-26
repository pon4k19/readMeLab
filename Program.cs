using System;

namespace Lab7
{
    /// <summary>
    /// Рассчитывает стоимость книг со скидкой для компании «Книга-Сити».
    /// Вариант 2: скидка 15%, если в прошлом месяце не было заказов.
    /// </summary>
    public class DiscountCalculator
    {
        /// <summary>
        /// Размер скидки для товаров без заказов в прошлом месяце.
        /// </summary>
        public decimal DiscountRate { get; private set; }

        /// <summary>
        /// Создаёт калькулятор скидки для компании «Книга-Сити».
        /// </summary>
        public DiscountCalculator()
        {
            DiscountRate = 0.15m;
        }

        /// <summary>
        /// Рассчитывает цену книги с учётом условия предоставления скидки.
        /// </summary>
        /// <param name="basePrice">Исходная цена книги.</param>
        /// <param name="hasOrdersLastMonth">Были ли заказы в прошлом месяце.</param>
        /// <returns>Цена со скидкой 15%, если заказов не было; иначе исходная цена.</returns>
        public decimal GetDiscountedPrice(decimal basePrice, bool hasOrdersLastMonth)
        {
            if (basePrice < 0)
            {
                throw new ArgumentOutOfRangeException("basePrice", "Цена не может быть отрицательной.");
            }

            if (hasOrdersLastMonth)
            {
                return basePrice;
            }

            return basePrice * (1m - DiscountRate);
        }
    }

    /// <summary>
    /// Содержит точку входа в консольное приложение лабораторной работы № 7.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Запускает демонстрацию расчёта скидки и выводит сведения об авторе.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        public static void Main(string[] args)
        {
            DiscountCalculator calculator = new DiscountCalculator();
            decimal basePrice = 1000m;
            bool hasOrdersLastMonth = false;
            decimal finalPrice = calculator.GetDiscountedPrice(basePrice, hasOrdersLastMonth);

            Console.WriteLine("Компания: Книга-Сити");
            Console.WriteLine("Вариант: 2");
            Console.WriteLine("Базовая цена книги: " + basePrice.ToString("0.00") + " руб.");
            Console.WriteLine("Были заказы в прошлом месяце: " + (hasOrdersLastMonth ? "да" : "нет"));
            Console.WriteLine("Скидка: " + (hasOrdersLastMonth ? "0%" : "15%"));
            Console.WriteLine("Цена после скидки: " + finalPrice.ToString("0.00") + " руб.");
            Console.WriteLine("Автор: Порсев, группа И-41");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
