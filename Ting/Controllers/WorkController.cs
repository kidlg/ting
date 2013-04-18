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
    public class WorkController : ApiController
    {
        private TingContext db = new TingContext();

        //// GET api/Work
        //[ApiDoc("获取所有的作品")]
        //public IEnumerable<Work> GetWorks()
        //{
        //    return db.Works.AsEnumerable();
        //}

        // GET api/Work/5
        [ApiDoc("根据ID获取作品")]
        [ApiParameterDoc("id", "作品ID")]
        public Work GetWork(int id)
        {
            Work work = db.Works.Find(id);
            if (work == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return work;
        }

        [ApiDoc("根据AnnoucerID获取作品列表（分页）")]
        [ApiParameterDoc("annoucerID", "朗读者ID")]
        public CommonModelDTO<Work> GetWorkByUserId(int annoucerID, int pagesize = 10, int pageindex = 1)
        {
            int count = db.Works.Count();
            var list = db.Works.Where(x => x.AnnouncerId == annoucerID).OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            var dto = new CommonModelDTO<Work>(list, count, pagesize, pageindex);
            return dto;
        }

        [ApiDoc("根据分类获取作品列表（分页）")]
        [ApiParameterDoc("cateid", "分类ID")]
        [HttpGet]
        public CommonModelDTO<Work> WorkByCateId(int cateid, int pagesize = 10, int pageindex = 1)
        {
            int count = db.Works.Count();
            var list = db.Works.Where(x => x.CateId == cateid).OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            var dto = new CommonModelDTO<Work>(list, count, pagesize, pageindex);
            return dto;
        }

        // PUT api/Work/5
        [ApiDoc("根据ID修改作品内容")]
        [ApiParameterDoc("id", "作品ID")]
        public HttpResponseMessage PutWork(int id, Work work)
        {
            if ( id == work.Id)
            {
                db.Entry(work).State = EntityState.Modified;

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

        // POST api/Work
        [ApiDoc("创建作品")]
        [ApiParameterDoc("category", "作品实体")]
        public HttpResponseMessage PostWork(Work work)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(work);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, work);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = work.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Work/5
        [ApiDoc("根据ID删除作品")]
        [ApiParameterDoc("id", "作品ID")]
        public HttpResponseMessage DeleteWork(int id)
        {
            Work work = db.Works.Find(id);
            if (work == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Works.Remove(work);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, work);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}