using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using System.Web.Security;
using System.Text;
using System.Xml.Linq;
using Ting.Areas.WeiXin.Models;

namespace Ting.Areas.WeiXin.Controllers
{
    public class DefaultController : Controller
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(DefaultController));
        const string Token = "kidlg"; //token
        private WeixinRobotContext db = new WeixinRobotContext();
        // GET: /WeiXin/Default/
        public ActionResult Viladate(string signature, string timestamp, string nonce, string echostr)
        {
           
            return View();
        }

        public string Test()
        {
            string path =  Request.PhysicalApplicationPath;
            Bl.AutoReplyBl.GetAutoReplyDic(path);
            return "1";
        }
        [HttpPost]
        public ActionResult Index()
        {
            try
            {
                var s = Request.InputStream;
                XElement xe = XElement.Load(s);
                var text = Weixin.XMLHelper.ConvertToTextMsg(xe);
                var result = new Weixin.Model.TextMsg();
                result.FromUserName = text.ToUserName;
                result.ToUserName = text.FromUserName;
                result.CreateTime = DateTime.Now.Ticks;
                result.FuncFlag = "1";
                result.MsgType = "text";
                /**************
                 * 这里的result要做成读取配置或者数据库的部分，方便经常更改回复的信息
                 * **************/
                var dicts = Bl.AutoReplyBl.GetAutoReplyDic(Request.PhysicalApplicationPath);
                #region ==== 消息 ====
                if (text.MsgType == "text")
                {
                    string content = text.Content.Trim();
                    if (content.StartsWith("#"))
                    {
                        //这个是命令
                        var strs = content.Substring(1).Split('+');
                        if (strs.Length == 2 && !string.IsNullOrEmpty(strs[0]) && !string.IsNullOrEmpty(strs[1]))
                        {
                            var qStr = strs[0];
                            var aStr = strs[1];
                            //命令正确
                            if (db.Questions.Where(x => x.Content == qStr && x.status == 1).Count() == 0)
                            {
                                //没学过
                                var q = new Question()
                                {
                                    Content = qStr,
                                    status = 1,
                                    CreateTime = DateTime.Now,
                                    UserOpenId = text.FromUserName
                                };
                                var question = db.Questions.Add(q);
                                db.SaveChanges();

                                var a = new Answer()
                                {
                                    Content = aStr,
                                    status = 1,
                                    QID = question.ID,
                                    CreateTime = DateTime.Now,
                                    UserOpenId = text.FromUserName
                                };
                                db.Answers.Add(a);
                                db.SaveChanges();
                                result.Content = dicts["lerning"];
                            }
                            else
                            {
                                result.Content = string.Format(dicts["known"], aStr);
                            }
                        }
                        else
                        {
                            //命令错误
                            result.Content = dicts["error"];
                        }

                    }
                    else if (content == "?" || content == "？")
                    {
                        result.Content = dicts["help"];
                    }
                    else
                    {
                        //这个是用户互动
                        var q = db.Questions.Where(x => x.Content == content).FirstOrDefault();
                        if (q != null)
                        {
                            var a = db.Answers.Where(x => x.QID == q.ID && x.status == 1).ToList();
                            if (a.Count > 0)
                            {
                                //有回复
                                result.Content = a.FirstOrDefault().Content;
                            }
                            else
                            {
                                //result.Content = "什么？我这个天才竟然不知道？你可以使用 【#问题+答案】的方式可以教我这个天才学习（比如【#你是谁+我是天才】)";
                            }
                        }
                        else
                        {
                            //result.Content = "什么？我这个天才竟然不知道？你可以使用 【#问题+答案】的方式可以教我这个天才学习（比如【#你是谁+我是天才】)";
                        }
                    }
                }
                #endregion
                #region ==== 事件 ====
                else if (text.MsgType == "event")
                {
                    if (text.Event == "subscribe")
                    {
                        //订阅
                        result.Content = dicts["subscribe"];
                    }
                }
                #endregion
                else
                {
                    //发送的不是文本
                    result.Content =dicts["nottext"];
                }
                ViewBag.Result = result;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }

            return View();
        }

        private bool CheckSignature(string sign,string timestamp,string nonce)
        {
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == sign)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
