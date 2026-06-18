using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using modestov_zad3_var3;
using System.Collections.Generic;

namespace modestov_zad3_var3
{
    // [TestClass] говорит студии, что этот класс содержит автоматические тесты
    [TestClass]
    public class AutoTests
    {
        // 1. Тест расчета качества Q для базового класса Otdel
        [TestMethod]
        public void Test_Otdel_KachestvoQ_CorrectCalculation()
        {

            // Формула: БазовыйОклад * (100 + Коэффициент)
            // 50000 * (100 + 2) = 50000 * 102 = 5 100 000
            var otdel = new Otdel("IT", 50000, 2, "Корпус А", 10);
            double expectedQ = 5100000;


            double actualQ = otdel.KachestvoQ();

            //  (Проверка результата)
            Assert.AreEqual(expectedQ, actualQ, "Расчет базового качества Q работает неверно!");
        }

        // 2. Тест расчета качества Qp для класса-потомка PotomokOtdela
        [TestMethod]
        public void Test_PotomokOtdela_KachestvoQ_WithHazard()
        {
            // Arrange (Подготовка данных)
            // Базовое Q = 10000 * (100 + 0) = 1 000 000
            // Формула потомка: Q + Q / P. При P = 2: 1000000 + 1000000 / 2 = 1 500 000
            var потомок = new PotomokOtdela("Сварщики", 10000, 0, "Цех 1", 5, 2, "Иванов И.И.");
            double expectedQp = 1500000;

            // (Выполнение действия)
            double actualQp = потомок.KachestvoQ();

            //  (Проверка результата)
            Assert.AreEqual(expectedQp, actualQp, "Расчет качества потомка Qp с учетом вредности P сломался!");
        }

        // 3. Тест работы LINQ-фильтра в классе Dannie
        [TestMethod]
        public void Test_Dannie_LinqFilter_CorrectFiltering()
        {
            // Arrange (Подготовка данных)
            var менеджер = new Dannie();

            // Добавляем три отдела с разными окладами
            менеджер.Dobavit("Дешевый", 20000, 1, "К1", 2);
            менеджер.Dobavit("Средний", 50000, 1, "К1", 3);
            менеджер.Dobavit("Богатый", 90000, 1, "К1", 4);

            // Фильтруем те, у кого оклад >= 50000. Должно остаться 2 отдела.
            double минимальныйОклад = 50000;

            // Act (Выполнение действия)
            List<Otdel> результатФильтра = менеджер.LinqFiltrOklada(минимальныйОклад);

            // Assert (Проверка результата)
            Assert.AreEqual(2, результатФильтра.Count, "LINQ-фильтр возвращает неверное количество элементов!");
            Assert.IsTrue(результатФильтра.Exists(o => o.Nazvnie == "Богатый"), "Фильтр потерял нужные данные!");
            Assert.IsFalse(результатФильтра.Exists(o => o.Nazvnie == "Дешевый"), "Фильтр пропустил лишние данные!");
        }
    }
}