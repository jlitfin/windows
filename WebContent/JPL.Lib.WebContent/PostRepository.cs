using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JPL.Lib.WebContent
{
    public class PostRepository : RepositoryBase
    {
        #region private members


        #endregion

        #region public accessors

        #endregion

        #region constructor

        public PostRepository()
        {
        }

        #endregion

        #region public methods

        //public List<Post> Read()
        //{
        //    List<Post> list = new List<Post>();
        //    DbCommand command = Database.GetStoredProcCommand("prc_post_sel");
        //    //
        //    // Optional Parameters:
        //    //
        //    //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

        //    using (IDataReader dr = Database.ExecuteReader(command))
        //    {
        //        while (dr.Read())
        //        {
        //            Post post = new Post();
        //            list.Add(Load(dr, post));
        //        }
        //    }

        //    return list;
        //}

        //public List<Post> Read(int threadId)
        //{
        //    List<Post> list = new List<Post>();
        //    DbCommand command = Database.GetStoredProcCommand("prc_post_sel_by_thread");
        //    //
        //    // Optional Parameters:
        //    //
        //    Database.AddInParameter(command, "@thread_id", DbType.Int32, threadId);

        //    using (IDataReader dr = Database.ExecuteReader(command))
        //    {
        //        while (dr.Read())
        //        {
        //            Post post = new Post();
        //            list.Add(Load(dr, post));
        //        }
        //    }

        //    return list;
        //}

        //public List<Post> Read(int threadId, DateTime postPeriod)
        //{
        //    List<Post> list = new List<Post>();
        //    DbCommand command = Database.GetStoredProcCommand("prc_post_sel_by_thread_period");
        //    //
        //    // Optional Parameters:
        //    //
        //    Database.AddInParameter(command, "@thread_id", DbType.Int32, threadId);
        //    Database.AddInParameter(command, "@post_period", DbType.DateTime, postPeriod);

        //    using (IDataReader dr = Database.ExecuteReader(command))
        //    {
        //        while (dr.Read())
        //        {
        //            Post post = new Post();
        //            list.Add(Load(dr, post));
        //        }
        //    }

        //    return list;
        //}

        public List<Post> Read(int threadId, int count, int postId = 0)
        {
            List<Post> list = new List<Post>();
            DbCommand command = Database.GetStoredProcCommand("prc_post_sel_by_thread_count");
            //
            // Optional Parameters:
            //
            Database.AddInParameter(command, "@thread_id", DbType.Int32, threadId);
            Database.AddInParameter(command, "@count", DbType.Int32, count);
            if (postId != 0)
            {
                Database.AddInParameter(command, "@post_id", DbType.Int32, postId);
            }

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Post post = new Post();
                    list.Add(Load(dr, post));
                }
            }

            return list;
        }

        public List<Post> ReadRecent()
        {
            List<Post> list = new List<Post>();
            DbCommand command = Database.GetStoredProcCommand("prc_post_sel_recent");
            //
            // Optional Parameters:
            //
            //Database.AddInParameter(command, "@param_name", DbType.Int32, field_name);

            using (IDataReader dr = Database.ExecuteReader(command))
            {
                while (dr.Read())
                {
                    Post post = new Post();
                    list.Add(Load(dr, post));
                }
            }

            return list;
        }



        public int Write(Post post, string updatedBy)
        {
            return Save(post, updatedBy);
        }


        public int WriteNew(Post post, string updatedBy)
        {
            return Add(post, updatedBy);
        }


        #endregion

        #region internal methods

        protected Post Load(IDataReader dr, Post post)
        {
            if (ColumnExists(dr, "id"))
            {
                if (dr["id"] == DBNull.Value)
                {
                    post.Id = 0;
                }
                else
                {
                    post.Id = Convert.ToInt32(dr["id"].ToString());
                }
            }
            if (ColumnExists(dr, "author"))
            {
                if (dr["author"] == DBNull.Value)
                {
                    post.Author = string.Empty;
                }
                else
                {
                    post.Author = Convert.ToString(dr["author"].ToString());
                }
            }
            if (ColumnExists(dr, "content"))
            {
                if (dr["content"] == DBNull.Value)
                {
                    post.Content = string.Empty;
                }
                else
                {
                    post.Content = Convert.ToString(dr["content"].ToString());
                }
            } 
            if (ColumnExists(dr, "post_date"))
            {
                if (dr["post_date"] == DBNull.Value)
                {
                    post.PostDate = DateTime.MinValue;
                }
                else
                {
                    post.PostDate = Convert.ToDateTime(dr["post_date"].ToString());
                }
            }
            if (ColumnExists(dr, "thread_id"))
            {
                if (dr["thread_id"] == DBNull.Value)
                {
                    post.ThreadId = 0;
                }
                else
                {
                    post.ThreadId = Convert.ToInt32(dr["thread_id"].ToString());
                }
            }
            if (ColumnExists(dr, "title"))
            {
                if (dr["title"] == DBNull.Value)
                {
                    post.Title = string.Empty;
                }
                else
                {
                    post.Title = Convert.ToString(dr["title"].ToString());
                }
            }


            return post;
        }


        internal int Add(Post post, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_post_ins");
            Database.AddInParameter(command, "@id", DbType.Int32, post.Id);
            Database.AddInParameter(command, "@author", DbType.String, post.Author);
            Database.AddInParameter(command, "@content", DbType.String, post.Content);
            Database.AddInParameter(command, "@post_date", DbType.DateTime, post.PostDate);
            Database.AddInParameter(command, "@thread_id", DbType.Int32, post.ThreadId);
            Database.AddInParameter(command, "@title", DbType.String, post.Title);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Convert.ToInt32(Database.ExecuteScalar(command));
        }


        internal int Save(Post post, string updatedBy)
        {

            DbCommand command = Database.GetStoredProcCommand("prc_post_upd");
            Database.AddInParameter(command, "@id", DbType.Int32, post.Id);
            Database.AddInParameter(command, "@author", DbType.String, post.Author);
            Database.AddInParameter(command, "@content", DbType.String, post.Content);
            Database.AddInParameter(command, "@post_date", DbType.DateTime, post.PostDate);
            Database.AddInParameter(command, "@thread_id", DbType.Int32, post.ThreadId);
            Database.AddInParameter(command, "@title", DbType.String, post.Title);
            Database.AddInParameter(command, "@updated_by", DbType.String, updatedBy);



            return Database.ExecuteNonQuery(command);
        }


        #endregion

    }

}
