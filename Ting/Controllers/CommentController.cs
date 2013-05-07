using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ting.Models;

namespace Ting.Controllers
{
    public class CommentController : ApiController
    {
        private TingContext db = new TingContext();

        //// GET api/Comment
        //[ApiDoc("获取所有的评论")]
        //public IEnumerable<Comment> GetComments()
        //{
        //    var comments = db.Comments;
        //    return comments.AsEnumerable();
        //}

        //[ApiDoc("获取所有的评论(分页)")]
        //public CommonModelDTO<Comment> GetComments(int pagesize = 10, int pageindex = 1)
        //{
        //    int count = db.Comments.Count();
        //    var list = db.Comments.OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
        //    var dto = new CommonModelDTO<Comment>(list, count, pagesize, pageindex);
        //    return dto;
        //}

        [ApiDoc("获取作品下所有的评论(分页)")]
        public CommonModelDTO<Comment> GetComments(int workid,int pagesize = 10, int pageindex = 1)
        {
            int count = db.Comments.Count();
            List<Comment> list;
            if (workid>0)
            {
                list = db.Comments.Where(x => x.WorkId == workid).OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            }
            else
            {
                list = db.Comments.OrderBy(x => x.Id).Skip((pageindex - 1) * pagesize).Take(pagesize).ToList();
            }
            var dto = new CommonModelDTO<Comment>(list, count, pagesize, pageindex);
            return dto;
        }

        // GET api/Comment/5
        [ApiDoc("根据ID获取评论")]
        [ApiParameterDoc("id","评论ID")]
        public Comment GetComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return comment;
        }

        // PUT api/Comment/5
        [ApiDoc("根据ID修改评论内容")]
        [ApiParameterDoc("id","评论ID")]
        public HttpResponseMessage PutComment(int id, Comment comment)
        {
            if ( id == comment.Id)
            {
                db.Entry(comment).State = EntityState.Modified;

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

        // POST api/Comment
        [ApiDoc("创建评论")]
        [ApiParameterDoc("category", "评论实体")]
        public HttpResponseMessage PostComment(Comment comment)
        {
   
                db.Comments.Add(comment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, comment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = comment.Id }));
                return response;
     
        }

        // DELETE api/Comment/5
        [ApiDoc("根据ID删除评论")]
        [ApiParameterDoc("id", "评论ID")]
        public HttpResponseMessage DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Comments.Remove(comment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}