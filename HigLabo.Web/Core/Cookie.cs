using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HigLabo.Web
{
    public class Cookie
    {
        public void Authenticate(String id, DateTime expireTime)
        {
            this.Authenticate(id, expireTime, false);
        }
        public void Authenticate(String id, DateTime expireTime, Boolean isPersistent)
        {
            var ticket = new FormsAuthenticationTicket(1, id, DateTime.Now, expireTime, isPersistent, "");
            this.Authenticate(ticket);
        }
        public void Authenticate(FormsAuthenticationTicket ticket)
        {
            var hc = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            hc.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(hc);
        }
        public void AddCookie(String name, String value)
        {
            var cookie = new HttpCookie(name, value);
            cookie.HttpOnly = true;
            this.Add(cookie);
        }
        public void Add(HttpCookie cookie)
        {
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public void Remove(String name)
        {
            HttpCookie hc = null;
            hc = new HttpCookie(name, "");
            hc.Expires = DateTime.Now.AddDays(-10);
            HttpContext.Current.Response.Cookies.Add(hc);
        }
        public void Clear()
        {
            HttpCookie hc = null;
            List<HttpCookie> l = new List<HttpCookie>();

            foreach (String key in HttpContext.Current.Request.Cookies.Keys)
            {
                hc = new HttpCookie(key, "");
                hc.Expires = DateTime.Now.AddDays(-1);
                l.Add(hc);
            }
            for (int i = 0; i < l.Count; i++)
            {
                HttpContext.Current.Response.Cookies.Add(l[i]);
            }
        }
        public void Signout()
        {
            this.Clear();
            FormsAuthentication.SignOut();
        }
    }
}