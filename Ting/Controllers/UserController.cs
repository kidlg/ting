using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Ting.Models;

namespace Ting.Controllers
{
    public class UserController : ApiController
    {
        private TingContext db = new TingContext();

        // GET api/User
        [ApiDoc("获取所有的用户")]
        public IEnumerable<User> GetUsers()
        {
            return db.Users.AsEnumerable();
        }

        // GET api/User/5
        [ApiDoc("根据ID获取用户")]
        [ApiParameterDoc("id", "用户ID")]
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }
        //[ApiDoc("根据用户名称获取用户ID")]
        //[ApiParameterDoc("name", "用户名称")]
        //public int GetUserIdByName(string name)
        //{
            
        //}

        // PUT api/User/5
        [ApiDoc("根据ID修改用户内容")]
        [ApiParameterDoc("id", "用户ID")]
        public HttpResponseMessage PutUser(int id, User user)
        {
            if ( id == user.Id)
            {
                db.Entry(user).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/User
        [ApiDoc("用户注册")]
        [ApiParameterDoc("user", "用户实体")]
        public HttpResponseMessage PostReg(User user)
        {
        
            db.Users.Add(user);
            db.SaveChanges();

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
            //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
            return response;

        }
        [ApiDoc("用户登录,返回用户ID，")]
        [ApiParameterDoc("name", "用户名")]
        public HttpResponseMessage PostLogin(string name,string password)
        {
            var user = db.Users.Where(x => x.Name.Equals(name) && x.Password.Equals(password)).FirstOrDefault();
            if (user!=null)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, user);
                return response;
            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest, "用户名或密码错误");
                return response;
            }
        }

        // DELETE api/User/5
        [ApiDoc("根据ID删除用户")]
        [ApiParameterDoc("id", "用户ID")]
        public HttpResponseMessage DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Users.Remove(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}