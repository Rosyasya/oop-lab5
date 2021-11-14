using System;

namespace SimpleClassConlsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[0];
            Product[] productRubbish = new Product[0];
            int menu = -1;
            string consoleRead;
            Console.WriteLine("Практична робота №3");
            Console.WriteLine("Корнута Ростислав П-42\n\n\n");


            while (menu != 0)
            {
                Console.WriteLine("\n- Меню -");
                Console.WriteLine("0 - Завершити програму");
                Console.WriteLine("1 - Добавити товари");
                Console.WriteLine("2 - Вивести інформацію про товар по його номеру(id)");
                Console.WriteLine("3 - Вивести список інформації всіх товарів");
                Console.WriteLine("4 - Вивести найдорожчий і найдешевший товар");
                Console.WriteLine("5 - Відсортувати список товарів за зростанням в ціні");
                Console.WriteLine("6 - Відсортувати список товарів за їх кількістю на складі");
                Console.WriteLine("Введіть цифру пункта меню:");
                consoleRead = Console.ReadLine();

                while (!Int32.TryParse(consoleRead, out menu))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                Console.Clear();

                switch (menu)
                {
                    case 1:
                        Product[] tempProducts = new Product[0];
                        if (products.Length > 0)
                            productRubbish = products;

                        tempProducts = ReadProductsArray();

                        products = new Product[tempProducts.Length + productRubbish.Length];

                        for (int value = 0; value < productRubbish.Length; value++)
                        {
                            products[value] = productRubbish[value];
                        }

                        int productRubbishCount = productRubbish.Length;

                        for (int value = 0; value < tempProducts.Length; value++)
                        {
                            products[productRubbishCount++] = tempProducts[value];
                        }
                        break;
                    case 2:
                        if (products.Length < 1)
                            break;
                        int productId;
                        Console.Write("\nВведіть номер(id) товару(1-");
                        Console.Write(products.Length);
                        Console.Write("):\n");
                        consoleRead = Console.ReadLine();

                        while (!Int32.TryParse(consoleRead, out productId))
                        {
                            Console.WriteLine("Помилка. Введіть ціле число:");

                            consoleRead = Console.ReadLine();
                        }

                        PrintProduct(products[productId - 1]);
                        break;
                    case 3:
                        PrintProducts(products);
                        break;
                    case 4:
                        if (products.Length < 1)
                            break;
                        GetProductsInfo(products);
                        break;
                    case 5:
                        products = SortProductsByPrice(products);
                        break;
                    case 6:
                        products = SortProductsByCount(products);
                        break;
                    default:
                        break;
                }
            }

            Console.ReadKey();
        }

        public static Product[] ReadProductsArray()
        {
            Product[] products = new Product[0];
            Product[] tempProducts = new Product[256];
            int addMore = 1;
            int tempValue = 0;
            int productsCount = 0;

            while (addMore != 0)
            {
                Product product = new Product();
                string consoleRead;
                int tempInt;

                Console.WriteLine("\n\n- Заповнення товара -");
                Console.WriteLine("Введіть назву: ");
                product.GSName = Console.ReadLine();

                Console.WriteLine("Введіть ціну:");
                bool goToNext = false;
                do
                {
                    try
                    {
                        product.GSPrice = Convert.ToDouble(Console.ReadLine());
                        goToNext = true;
                    }
                    catch
                    {
                        Console.WriteLine("Помилка. Введіть дробове число:");
                    }
                } while (goToNext == false);

                Currency currency = new Currency();

                Console.WriteLine("Введіть назву валюти ціни товару(!НЕ ГРН!):");
                currency.GSName = Console.ReadLine();

                Console.WriteLine("Введіть курс " + currency.GSName + ":");
                goToNext = false;
                do
                {
                    try
                    {
                        currency.GSExRate = Convert.ToDouble(Console.ReadLine());
                        goToNext = true;
                    }
                    catch
                    {
                        Console.WriteLine("Помилка. Введіть дробове число:");
                    }
                } while (goToNext == false);

                product.GSCost = currency;

                Console.WriteLine("Введіть кількість товару:");
                consoleRead = Console.ReadLine();
                while (!Int32.TryParse(consoleRead, out tempValue))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                product.GSQuantity = tempValue;

                Console.WriteLine("Введіть виробника товару:");
                product.GSProducer = Console.ReadLine();

                Console.WriteLine("Введіть масу товару(1 од.):");
                consoleRead = Console.ReadLine();
                while (!Int32.TryParse(consoleRead, out tempValue))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                product.GSWeight = tempValue;

                tempProducts[productsCount++] = product;

                Console.WriteLine("\nДобавити ще 1 товар? \n0 - Ні \n1 - Так");
                consoleRead = Console.ReadLine();
                while (!Int32.TryParse(consoleRead, out tempValue))
                {
                    Console.WriteLine("Помилка. Введіть ціле число:");

                    consoleRead = Console.ReadLine();
                }

                if (tempValue == 0)
                {
                    products = new Product[productsCount];

                    for (int i = 0; i < productsCount; i++)
                    {
                        products[i] = tempProducts[i];
                    }

                    addMore = 0;
                }
            }

            return products;
        }

        public static void PrintProduct(Product product)
        {
            Console.WriteLine("\n- Інформація про товар -");
            Console.WriteLine("Назва: {0}", product.GSName);
            Console.WriteLine("Ціна: {0}", product.GSPrice);
            Console.WriteLine("Валюта:");
            Console.WriteLine("    Назва: {0}", product.GSCost.GSName);
            Console.WriteLine("    Курс: {0}", product.GSCost.GSExRate);
            Console.WriteLine("Кількість: {0}", product.GSQuantity);
            Console.WriteLine("Виробник: {0}", product.GSProducer);
            Console.WriteLine("Маса: {0}", product.GSWeight);
        }

        public static void PrintProducts(Product[] products)
        {
            for (int value = 0; value < products.Length; value++)
            {
                PrintProduct(products[value]);
            }
        }

        public static void Swap(ref Product product1, ref Product product2)
        {
            var tempProduct = product1;
            product1 = product2;
            product2 = tempProduct;
        }

        public static void GetProductsInfo(Product[] products)
        {
            Console.Clear();

            for (int value = 1; value < products.Length; value++)
            {
                for (int value2 = 0; value2 < products.Length - value; value2++)
                {
                    if (products[value2].GetPriceInUAH() > products[value2 + 1].GetPriceInUAH())
                    {
                        Swap(ref products[value2], ref products[value2 + 1]);
                    }
                }
            }

            Console.WriteLine("Найдорожчий товар: \n     Назва: " + products[products.Length - 1].GSName +
                "\nЦіна в грн: " + products[products.Length - 1].GetPriceInUAH());
            Console.WriteLine("Найдешевший товар: \n     Назва: " + products[0].GSName + "\nЦіна в грн: " 
                + products[0].GetPriceInUAH());
        }

        public static Product[] SortProductsByPrice(Product[] products)
        {
            for (int value = 1; value < products.Length; value++)
            {
                for (int value2 = 0; value2 < products.Length - value; value2++)
                {
                    if (products[value2].GetPriceInUAH() > products[value2 + 1].GetPriceInUAH())
                    {
                        Swap(ref products[value2], ref products[value2 + 1]);
                    }
                }
            }

            return products;
        }

        public static Product[] SortProductsByCount(Product[] products)
        {
            for (int value = 1; value < products.Length; value++)
            {
                for (int value2 = 0; value2 < products.Length - value; value2++)
                {
                    if (products[value2].GSQuantity < products[value2 + 1].GSQuantity)
                    {
                        Swap(ref products[value2], ref products[value2 + 1]);
                    }
                }
            }

            return products;
        }
    }
}
