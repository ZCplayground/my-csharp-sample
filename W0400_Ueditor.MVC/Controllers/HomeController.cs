﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using W0400_Ueditor.MVC.Models;

namespace W0400_Ueditor.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 创建.
        /// </summary>
        /// <returns></returns>
        public ActionResult Creater()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Creater(EditData data)
        {
            Session["Text"] = data;

            return RedirectToAction("Index");
        }




        /// <summary>
        /// 编辑.
        /// </summary>
        /// <returns></returns>
        public ActionResult Editor()
        {
            EditData data = Session["Text"] as EditData;
            return View(data);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Editor(EditData data)
        {
            Session["Text"] = data;

            return RedirectToAction("Index");
        }




        /// <summary>
        /// 查看
        /// </summary>
        /// <returns></returns>
        public ActionResult Viewer()
        {
            EditData data = Session["Text"] as EditData;

            return View(data);
        }


    }
}
