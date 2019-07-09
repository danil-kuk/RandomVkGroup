using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace RandomVkGroupApp
{
    class Generator
    {
        static readonly VkApi vk = new VkApi();
        readonly ConfigSettings settings;
        public Generator(ConfigSettings settings)
        {
            this.settings = settings;
            try
            {
                Auth();
                Console.WriteLine("Вход выполнен");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка авторизации! Проверьте данные в файле config.json");
            }
        }

        private void Auth()
        {
            vk.Authorize(new ApiAuthParams
            {
                ApplicationId = settings.AppId,
                Login = settings.Login,
                Password = settings.Password,
                Settings = Settings.All
            });
        }

        public void Generate()
        {
            var groupId = new Random().Next(999999).ToString();
            Console.WriteLine(TryGetGroupName(groupId) + " (https://vk.com/club" + groupId + ")");
        }

        private string TryGetGroupName(string groupId)
        {
            try
            {
                var group = vk.Groups.GetById(null, groupId, null);
                return group[0].Name;
            }
            catch (Exception)
            {
                return "id" + groupId;
            }
        }
    }
}
