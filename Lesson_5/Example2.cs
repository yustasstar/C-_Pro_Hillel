namespace Lesson5.v2
{
    // generic interfaces:

    //Ковариантность: позволяет использовать более конкретный тип, чем заданный изначально

    //Контравариантность: позволяет использовать более универсальный тип, чем заданный изначально

    //Инвариантность: позволяет использовать только заданный тип

    // Ковариантные интерфейсы
    interface IMessenger<out T>
    {
        T WriteMessage(string text);
    }

    class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;
    }

    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }

    class EmailMessenger : IMessenger<EmailMessage>
    {
        public EmailMessage WriteMessage(string text)
        {
            return new EmailMessage($"Email: {text}");
        }
    }

    // Контравариантные интерфейсы
    interface IMessengerV2<in T>
    {
        void SendMessage(T message);
    }
    class SimpleMessenger : IMessengerV2<Message>
    {
        public void SendMessage(Message message)
        {
            Console.WriteLine($"message: {message.Text}");
        }
    }

    // Совмещение ковариантности и контравариантности
    interface IMessengerV3<in T, out K>
    {
        void SendMessage(T message);
        K WriteMessage(string text);
    }
    class SimpleMessengerV3 : IMessengerV3<Message, EmailMessage>
    {
        public void SendMessage(Message message)
        {
            Console.WriteLine($"message: {message.Text}");
        }
        public EmailMessage WriteMessage(string text)
        {
            return new EmailMessage($"Email: {text}");
        }
    }

    public static class Example2
    {
        public static void Test()
        {
            // Ковариантность
            //IMessenger<Message> outlook = new EmailMessenger();
            //Message message = outlook.WriteMessage("Hello World");
            //Console.WriteLine(message.Text);    // Email: Hello World


            //IMessenger<EmailMessage> emailClient = new EmailMessenger();
            //IMessenger<Message> messenger = emailClient;
            //Message emailMessage = messenger.WriteMessage("Hi!");
            //Console.WriteLine(emailMessage.Text);    // Email: Hi!

            // without out -> error
            //IMessenger<Message> outlook = new EmailMessenger();

            //IMessenger<EmailMessage> emailClient = new EmailMessenger();
            //IMessenger<Message> messenger = emailClient;  // ! Ошибка

            // Контравариантность
            //IMessengerV2<EmailMessage> outlook = new SimpleMessenger();
            //outlook.SendMessage(new EmailMessage("Hi!"));

            //IMessengerV2<Message> telegram = new SimpleMessenger();
            //IMessengerV2<EmailMessage> emailClient = telegram;
            //emailClient.SendMessage(new EmailMessage("Hello"));

            // Совмещение ковариантности и контравариантности
            IMessengerV3<EmailMessage, Message> messenger = new SimpleMessengerV3();
            Message message = messenger.WriteMessage("Hello World");
            Console.WriteLine(message.Text);
            messenger.SendMessage(new EmailMessage("Test"));

            IMessengerV3<EmailMessage, EmailMessage> outlook = new SimpleMessengerV3();
            EmailMessage emailMessage = outlook.WriteMessage("Message from Outlook");
            outlook.SendMessage(emailMessage);

            IMessengerV3<Message, Message> telegram = new SimpleMessengerV3();
            Message simpleMessage = telegram.WriteMessage("Message from Telegram");
            telegram.SendMessage(simpleMessage);
        }
    }
}
