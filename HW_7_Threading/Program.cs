
class BarberShop
{
    private static readonly Semaphore customers = new Semaphore(0, int.MaxValue); 
    private static readonly Semaphore barbers = new Semaphore(0, 1);              
    private static readonly Semaphore mutex = new Semaphore(1, 1);                
    private static readonly int waitingRoomSeats = 4;
    private static int waiting;


    static void Barber()
    {
        while (true)
        {
            Console.WriteLine("Парикмахер засыпает, так как нет клиентов.");
            customers.WaitOne(); 
            Console.WriteLine("Парикмахера разбудили!");

            mutex.WaitOne();
            waiting--; // Клиент садится на стрижку, уменьшаем число ожидающих
            Console.WriteLine($"Клиентов в очереди: {waiting}");
            barbers.Release(); // Сигнализируем, что парикмахер готов к стрижке
            mutex.Release();

            Console.WriteLine("Парикмахер стрижет клиента...");
            Thread.Sleep(3000); // Моделируем время на стрижку
        }
    }

    static void Customer(int customerId)
    {
        mutex.WaitOne();
        if (waiting < waitingRoomSeats) // Проверка наличия свободного места в приемной
        {
            waiting++; // Клиент занимает кресло в приемной
            Console.WriteLine($"Клиент {customerId} ожидает. Ожидающих: {waiting}");
            customers.Release(); // Увеличиваем счетчик клиентов, чтобы разбудить парикмахера
            mutex.Release();

            barbers.WaitOne(); // Ожидание, пока парикмахер будет готов
            Console.WriteLine($"Клиент {customerId} садится на стрижку.");
        }
        else
        {
            mutex.Release();
            Console.WriteLine($"Клиент {customerId} уходит, так как все кресла заняты.");
        }
    }

    public static void Main()
    {
        var barberThread = new Thread(new ThreadStart(Barber));
        barberThread.Start();

        // Имитируем приход 10 клиентов с некоторым интервалом
        for (int i = 1; i <= 10; i++)
        {
            int customerId = i;
            var customerThread = new Thread(() => Customer(customerId));
            customerThread.Start();
            Thread.Sleep(1000); // Интервал между появлением клиентов
        }

        barberThread.Join();
    }
}
