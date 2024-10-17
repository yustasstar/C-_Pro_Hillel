//using System;
//using DependencyInversionPrinciple.Message;

//namespace DependencyInversionPrinciple
//{
//    class Program
//    {
//        private static void Main()
//        {
//            Console.WriteLine("---Dependency Inversion Principle---");

//            Console.WriteLine("Select a notification type: ");
//            Console.WriteLine("1. Email");
//            Console.WriteLine("2. Sms");

//            var option = Convert.ToInt32(Console.ReadLine());

//            Notification notifications;
//            var message = string.Empty;

//            switch (option)
//            {
//                case 1:
//                    var email = new Email
//                    {
//                        ToAddress = "test@test.com",
//                        Subject = "This is an email message",
//                        Content = "Some text",
//                    };

//                    notifications = new Notification(email);
//                    message = notifications.GetEmail();
//                    break;
//                case 2:
//                {
//                    var sms = new Sms
//                    {
//                        PhoneNumber = "+38095123456",
//                        Message = "This is a text message",
//                    };

//                    notifications = new Notification(sms);
//                    message = notifications.GetSms();
//                    break;
//                }
//            }

//            Console.WriteLine("\n---Notification---\n");
//            Console.WriteLine(message);
//        }
//    }
//}
