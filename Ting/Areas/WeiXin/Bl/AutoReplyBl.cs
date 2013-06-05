using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Ting.Areas.WeiXin.Bl
{
    public static class AutoReplyBl
    {
        public static Dictionary<string, string> GetAutoReplyDic(string rootPath)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var bytes =  File.ReadAllBytes(Path.Combine(rootPath,@"App_Data\xml\autoReply.xml"));
            XElement xe;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                {
                    xe = XElement.Load(sr);
                }
            }
            var list = xe.Elements("item");
            foreach (var item in list)
            {
                dic.Add(item.Attribute("key").Value, item.Value);
            }

            return dic;
        }
    }
}