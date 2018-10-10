using System.Collections.Concurrent;

namespace SIS.HTTP.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions 
            = new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            if (sessions.ContainsKey(id))
            {
                return null;
            }
            else
            {
                return sessions.GetOrAdd(id, _ => new HttpSession(id));
            }
        }
    }
}
