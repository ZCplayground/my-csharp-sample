﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


using System.Data.Entity;
using System.Data.Entity.Infrastructure;



namespace A0622_EF_OneToMany.Sample
{
    public class Test
    {

        /// <summary>
        /// 获取创建数据库表的初始脚本.
        /// </summary>
        /// <returns></returns>
        public String GetCreateDatabaseScript()
        {
            using (MyDbContext context = new MyDbContext())
            {

                // 在 Oracle 环境下， 如果下面这个语句， 也抱错的话...
                // 错误内容一般是  名称已被使用什么的。
                // 测试情况下， 简单的处理
                // 就是抛弃幻想， DROP user 数据库用户 cascade;
                // 然后重建用户。
                var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();

                return dbCreationScript;
            }

        }



        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="data"></param>
        public void SaveSchoolData(School data)
        {

            using (MyDbContext context = new MyDbContext()) {

                if (data.SchoolID == 0)
                {
                    context.SchoolDbSet.Add(data);
                }
                else
                {

                    School dbData = context.SchoolDbSet.Find(data.SchoolID);

                    // 先从上下文中的旧实体获取跟踪
                    DbEntityEntry entry = context.Entry(dbData);

                    // 把新值设置到旧实体上
                    entry.CurrentValues.SetValues(data);  

                }


                context.SaveChanges();

            }

            
        }



        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="data"></param>
        public void SaveTeacherData(Teacher data)
        {
            using (MyDbContext context = new MyDbContext())
            {
                if (data.TeacherID == 0)
                {
                    context.TeacherDbSet.Add(data);
                }
                else
                {

                    Teacher dbData = context.TeacherDbSet.Find(data.TeacherID);

                    // 先从上下文中的旧实体获取跟踪
                    DbEntityEntry entry = context.Entry(dbData);

                    // 把新值设置到旧实体上
                    entry.CurrentValues.SetValues(data);  
                }

                context.SaveChanges();
            }
        }







        /// <summary>
        /// 批量新增.
        /// </summary>
        /// <param name="schoolList"></param>
        public void BatchInsert(List<School> schoolList)
        {
            using (MyDbContext context = new MyDbContext())
            {
                // 遍历每一个学校.
                foreach (var school in schoolList)
                {
                    context.SchoolDbSet.Add(school);
                } 
                context.SaveChanges();
            }
        }




        /// <summary>
        /// 获取学校列表.
        /// </summary>
        /// <returns></returns>
        public List<School> GetSchoolList()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var query =
                    from data in context.SchoolDbSet.Include("SchoolTeachers")
                    select data;

                return query.ToList();
            }
        }

    }
}
