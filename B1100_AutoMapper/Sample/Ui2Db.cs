﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;


using B1100_AutoMapper.Model;



namespace B1100_AutoMapper.Sample
{

    /// <summary>
    /// 测试  画面 的类， 转换为  数据库的类.
    /// </summary>
    class Ui2Db
    {

        public Ui2Db()
        {
            Mapper.CreateMap<TestUiClass, TestDbClass>();
        }



        /// <summary>
        /// 测试一个新增的操作.
        /// </summary>
        public void DoTest1()
        {
            TestUiClass uiClass = new TestUiClass()
            {
                ID = 2,
                Name = "测试2",
                IsActive = true,
            };

            // 测试将其转换为 UI 上使用的类.
            TestDbClass dbClass = Mapper.Map<TestUiClass, TestDbClass>(uiClass);


            Console.WriteLine("UI to DB......");

            Console.WriteLine("UI类 = {0}", uiClass);
            Console.WriteLine("DB类 = {0}", dbClass);


            Console.WriteLine("UI to DB finish!!!");
        }




        /// <summary>
        /// 测试一个更新的操作.
        /// </summary>
        public void DoTest2()
        {
            // 先 手动 模拟一个  从数据库中获取的类.
            TestDbClass dbClass = new TestDbClass()
            {
                ID = 3,
                Name = "测试3",
                IsActive = true,


                CreateTime = DateTime.Now,
                LastUpdateTime = DateTime.Now,

                CreateUser = "Tester",
                LastUpdateUser = "Tester",
            };



            // 这里模拟 画面上， 更新了数据.
            TestUiClass uiClass = new TestUiClass()
            {
                ID = 3,
                Name = "测试3x7=21",
                IsActive = false,
            };



            // 注意： 
            // 前面的 DoTest1 中的处理， 是 通过 ui 类， 创建一个 db 类.
            // 这里的处理， 是通过 ui 类， 更新 db 类.
            Mapper.Map(uiClass, dbClass);

            Console.WriteLine("UI to DB......");

            Console.WriteLine("UI类 = {0}", uiClass);
            Console.WriteLine("DB类 = {0}", dbClass);


            Console.WriteLine("UI to DB finish!!!");

        }
    }

}
