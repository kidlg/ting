using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Ting.Models;
using System.Threading.Tasks;


namespace Ting.Controllers
{
    public class SectionController : ApiController
    {
        private TingContext db = new TingContext();

        //// GET api/Section
        // [ApiDoc("获取所有的剧集")]
        //public IEnumerable<Section> GetSections()
        //{
  
        //    return db.Sections.AsEnumerable();
        //}

        // // GET api/Section
        // [ApiDoc("获取所有的剧集（分页）")]
        // public CommonModelDTO<Section> GetSections(int pagesize = 10, int pageindex = 1)
        // {
        //     int count = db.Sections.Count();
        //     var list = db.Sections.OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //     var dto = new CommonModelDTO<Section>(list, count, pagesize, pageindex);
        //     return dto;
        // }

         // GET api/Section
         [ApiDoc("根据workid获取所有的剧集（分页）")]
         public CommonModelDTO<Section> GetSections(int workid,int pagesize = 10, int pageindex = 1)
         {
             int count = db.Sections.Count();
             List<Section> list;
             if (workid>0)
             {
                 list = db.Sections.Where(x => x.WorkId == workid).OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
             }
             else
             {
                 list = db.Sections.OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
             }
             var dto = new CommonModelDTO<Section>(list, count, pagesize, pageindex);
             return dto;
         }

        // GET api/Section/5
         [ApiDoc("根据ID获取剧集")]
         [ApiParameterDoc("id", "剧集ID")]      
        public Section GetSection(int id)
        {
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return section;
        }

        // PUT api/Section/5
         [ApiDoc("根据ID修改剧集内容")]
         [ApiParameterDoc("id", "剧集ID")]
        public HttpResponseMessage PutSection(int id, Section section)
        {
            if ( id == section.Id)
            {
                db.Entry(section).State = EntityState.Modified;

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

        // POST api/Section
         [ApiDoc("创建剧集")]
         [ApiParameterDoc("category", "剧集实体")]
        //public HttpResponseMessage PostSection(Section section)
        //{
        //    if (ModelState.IsValid)
        //    {

     

        //        db.Sections.Add(section);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, section);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = section.Id }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}
        [HttpPost]
        [ActionName("Upload")]
         public Task<HttpResponseMessage> Upload()
         {
             if (!Request.Content.IsMimeMultipartContent())
             {
                 throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
             }
             string root = HttpContext.Current.Server.MapPath("~/Sounds");
             string urlHost = HttpContext.Current.Request.Url.Host;
             var sectionPath = "";
             var provider = new MultipartFormDataStreamProvider(root);

                 // 读取表单数据
                 var task = Request.Content.ReadAsMultipartAsync(provider).ContinueWith<HttpResponseMessage>(
                     t =>
                     {
                         if (t.IsFaulted || t.IsCanceled)
                         {
                             Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                         }
                         foreach (MultipartFileData file in provider.FileData)
                         {
                             var ext = file;
                             var filename = Path.GetFileName(System.Guid.NewGuid()+".mp3");
                             File.Move(file.LocalFileName,Path.Combine(root,filename));
                             sectionPath = @"http://"+urlHost + "/Sounds/" + filename;
                         }
                         return Request.CreateResponse(HttpStatusCode.OK, sectionPath);
                     });


                 return task;
         }

        // DELETE api/Section/5
         [ApiDoc("根据ID删除剧集")]
         [ApiParameterDoc("id", "剧集ID")]
        public HttpResponseMessage DeleteSection(int id)
        {
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Sections.Remove(section);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, section);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}