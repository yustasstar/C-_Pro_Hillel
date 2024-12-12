using System;
using System.Linq;
using System.Web.Mvc;
using AjaxChat.Models;

namespace AjaxChat.Controllers
{
    public class HomeController : Controller
    {
        static ChatModel chatModel;

        public ActionResult Index(string user, bool? logOn, bool? logOff, string chatMessage)
        {
            try
            {
                if (chatModel == null) chatModel = new ChatModel();

                // если обычный запрос, просто возвращаем представление
                if (!Request.IsAjaxRequest())
                {
                    return View(chatModel);
                }
                else if (logOn != null && (bool)logOn)
                {
                    //проверяем, существует ли уже такой пользователь
                    if (chatModel.Users.FirstOrDefault(u => u.Name == user) != null)
                    {
                        throw new Exception("Пользователь с таким ником уже существует!");
                    }
                    else
                    {
                        // добавляем в список нового пользователя
                        chatModel.Users.Add(new ChatUser()
                        {
                            Name = user,
                            LoginTime = DateTime.Now,
                        });

                        // добавляем в список сообщений сообщение о новом пользователе
                        chatModel.Messages.Add(new ChatMessage()
                        {
                            Text = user +" вошел в чат",
                            Date = DateTime.Now
                        });
                    }

                    return PartialView("ChatRoom", chatModel);
                }
                else if (logOff != null && (bool)logOff)
                {
                    LogOff(chatModel.Users.FirstOrDefault(u => u.Name == user));
                    return PartialView("History", chatModel);
                }
                else
                {
                    ChatUser currentUser = chatModel.Users.FirstOrDefault(u => u.Name == user);                

                    // добавляем в список сообщений новое сообщение
                    if (!string.IsNullOrEmpty(chatMessage))
                    {
                        chatModel.Messages.Add(new ChatMessage()
                        {
                            User = currentUser,
                            Text = chatMessage,
                            Date = DateTime.Now
                        });
                    }

                    return PartialView("History", chatModel);
                }
            }
            catch (Exception ex)
            {
                //в случае ошибки посылаем статусный код 500
                Response.StatusCode = 500;
                return Content(ex.Message);
            }
        }

        // при выходе пользователя удаляем его из списка
        public void LogOff(ChatUser user)
        {
            chatModel.Users.Remove(user);
            chatModel.Messages.Add(new ChatMessage()
            {
                Text = user.Name + " покинул чат.",
                Date = DateTime.Now
            });
        }
    }
}