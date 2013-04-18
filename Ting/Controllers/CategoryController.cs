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
    public class CategoryController : ApiController
    {
        private TingContext db = new TingContext();

        //// GET api/Category
        //[ApiDoc("获取所有的分类")]
        //public IEnumerable<Category> GetCategories()
        //{
        //    return db.Categories.AsEnumerable();
        //}
        //[ApiDoc("获取所有的分类（分页）")]
        //public CommonModelDTO<Category> Categories(int pagesize=10, int pageindex=1)
        //{
        //    int count = db.Categories.Count();
        //    var list = db.Categories.OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //    var dto = new CommonModelDTO<Category>(list, count, pagesize, pageindex);
        //    return dto;
        //}

        [ApiDoc("根据分类ID获取子分类（分页）")]
        public CommonModelDTO<Category> GetCategories(int cateid,int pagesize=10, int pageindex=1)
        {
            int count = db.Categories.Count();
            List<Category> list;
            if (cateid>0)
            {
                list = db.Categories.Where(x => x.ParentCateId == cateid).OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();   
            }
            else
            {
                list = db.Categories.OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();   
            }
             
            var dto = new CommonModelDTO<Category>(list, count, pagesize, pageindex);
            return dto;
        }

        // GET api/Category/5
        [ApiDoc("根据ID获取单个分类")]
        [ApiParameterDoc("id","分类ID")]
        public Category GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return category;
        }

        // PUT api/Category/5
        [ApiDoc("根据ID修改分类信息")]
        [ApiParameterDoc("id","分类ID")]
        public HttpResponseMessage PutCategory(int id, Category category)
        {
            if ( id == category.Id)
            {
                db.Entry(category).State = EntityState.Modified;

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

        // POST api/Category
        [ApiDoc("创建分类信息")]
        [ApiParameterDoc("category", "分类实体")]
        public HttpResponseMessage PostCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, category);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = category.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Category/5
        [ApiDoc("根据ID删除分类信息")]
        [ApiParameterDoc("id", "分类ID")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Categories.Remove(category);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, category);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}