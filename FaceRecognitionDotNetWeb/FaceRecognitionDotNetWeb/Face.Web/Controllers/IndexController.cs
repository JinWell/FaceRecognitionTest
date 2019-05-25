using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Face.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload(FormCollection form)
        {
            string size = Request.Files[0].ContentLength.ToString();//文件大小
            string type = Request.Files[0].ContentType;//文件类型
            string name = Request.Files[0].FileName;
            var newFileName = Guid.NewGuid() + "." + name.Split('.')[1];
            string path = Server.MapPath("~/Content/UpfileImg/") + newFileName ; //服务器端保存路径
            HttpPostedFileBase files = Request.Files[0];
            files.SaveAs(path);
            return Json(new {
                filePath="/Content/UpfileImg/" + newFileName,
                fileName=newFileName
            }); 
        }

            /// <summary>
            /// 将文件转换成Base64格式
            /// </summary>
            public string FileToBase64(string fileName)
        {
            string result = "";
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] byteArray = new byte[fs.Length];
                    fs.Read(byteArray, 0, byteArray.Length);
                    result = Convert.ToBase64String(byteArray);
                }
            }
            catch
            {
                result = "";
            }
            return result;

        }
    }
}