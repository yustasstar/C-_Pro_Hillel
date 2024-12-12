﻿using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AppWithoutMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Kestrel представляет кроссплатформенный веб-сервер, основанный на кросплатформенной библиотеке асинхронного ввода/вывода libuv. 
            // Kestrel использует сокеты и полностью состоит из управляемого кода. 

            // Content root представляет базовый путь к любому содержимому и контенту веб-приложения. 
            // По умолчанию этот путь аналогичен текущему каталогу выполняемого приложения. 

            // Для создания хоста веб-приложения используется класс WebHostBuilder из пространства имен Microsoft.AspNetCore.Hosting
            var host = new WebHostBuilder()
                .UseKestrel() // устанавливает в качестве веб-сервера Kestrel
                .UseContentRoot(Directory.GetCurrentDirectory()) // определяет каталог содержимого приложения или Content Root
                .UseIISIntegration() // обеспечивает интеграцию приложения с веб-сервером IIS, через который по умолчанию перенаправляются запросы на сервер Kestrel
                .UseStartup<Startup>() //  устанавливается стартовый класс приложения - класс Startup, с которого будет начинаться обработка входящих запросов
                .Build(); // создает хост-объект IWebHost, в рамках которого развертывается веб-приложение
            host.Run(); // запускает приложение, и веб-сервер начинает прослушивать все входящие HTTP-запросы
        }
    }
}
