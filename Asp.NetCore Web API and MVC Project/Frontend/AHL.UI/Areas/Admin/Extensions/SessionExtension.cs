using System.Text.Json;

namespace AHL.UI.Areas.Admin.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object data)
        {
            session.SetString(key, JsonSerializer.Serialize(data));
        }
        public static T GetObject<T>(this ISession session, string key)
        {
            var sessionJsonData = session.GetString(key);
            return  JsonSerializer.Deserialize<T>(sessionJsonData);


        }
    }
}
