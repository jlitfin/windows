using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace JPL.Lib.WebContent
{
    public class PostManager
    {
        private PostRepository __postRepos = new PostRepository();
        private ThreadRepository __threadRepos = new ThreadRepository();
        private static KeyWordRepository __keyWordRepos = new KeyWordRepository();
        private static KeyWordIndexRepository __indexRepos = new KeyWordIndexRepository();

        private List<Thread> __threads;
        private List<Post> __recent;

        public PostManager()
        {
            __threads = __threadRepos.Read();
            __recent = new List<Post>();
        }

        public List<Post> Recent
        {
            get
            {
                if (__recent.Count == 0)
                {
                    __recent = __postRepos.ReadRecent();
                }

                return __recent;
            }
        }

        public List<Thread> Threads
        {
            get
            {
                return __threads;
            }
        }

        public int AddPost(Post post, string user)
        {
            Dictionary<string, SkipWord> dict = __indexRepos.GetSkipWords();
            string[] c = post.Content.Split();
            for (int i = 0; i < c.Length; ++i)
            {
                c[i] = Strip(c[i]);
            }

            Dictionary<string, int> tokens = new Dictionary<string, int>();
            if (c != null & c.Length > 0)
            {
                List<string> l = (from w in c
                                  orderby w
                                  select w).ToList<string>();
                foreach (string str in l)
                {
                    if (!dict.ContainsKey(str) && !string.IsNullOrWhiteSpace(str))
                    {
                        if (!tokens.ContainsKey(str))
                        {
                            tokens.Add(str, 0);
                        }
                        tokens[str]++;
                    }
                }
            }
            
            post.Id = __postRepos.WriteNew(post, user);
            if (post.Id > 0)
            {
                foreach (Thread t in __threads)
                {
                    if (t.Id == post.ThreadId)
                    {
                        t.Statistics = __threadRepos.GetThreadStats(post.ThreadId);
                        break;
                    }
                }

                List<KeyWord> keyWords = new List<KeyWord>();
                List<KeyWordIndex> indexes = new List<KeyWordIndex>();
                foreach (KeyValuePair<string, int> kv in tokens)
                {
                    KeyWord kw = new KeyWord();
                    kw.Word = kv.Key;
                    keyWords.Add(kw);

                    KeyWordIndex kwi = new KeyWordIndex();
                    kwi.Count = kv.Value;
                    kwi.PostId = post.Id;
                    indexes.Add(kwi);
                }
                __keyWordRepos.Write(keyWords, user);
                __indexRepos.Write(indexes, user);
            }

            return post.Id;
        }

        public void AddThread(Thread thread)
        {
        }

        public List<Post> GetPostsForGroup(int threadId, int group)
        {
            List<Post> list = new List<Post>();
            foreach (Thread t in __threads)
            {
                if (t.Id == threadId)
                {
                    int ndx = group * Constants.POST_GROUP_COUNT;
                    if (t.Statistics.Count > ndx)
                    {
                        list = __postRepos.Read(threadId, Constants.POST_GROUP_COUNT, t.Statistics[ndx].PostId);
                    }
                }
            }

            return list;
        }

        public List<Post> GetNextPostGroupFor(int threadId, int postId)
        {
            List<Post> list = new List<Post>();
            foreach (Thread t in __threads)
            {
                if (t.Id == threadId)
                {
                    for (int i = 0; i < t.Statistics.Count; ++i)
                    {
                        if (t.Statistics[i].PostId == postId)
                        {
                            if (i < t.Statistics.Count - 1)
                            {
                                list = __postRepos.Read(threadId, Constants.POST_GROUP_COUNT, t.Statistics[i + 1].PostId);
                                return list;
                            }
                        }
                    }
                }
            }           
            return list;
        }

        public List<Post> GetPostGroupFor(int threadId, int postId)
        {
            List<Post> list = __postRepos.Read(threadId, Constants.POST_GROUP_COUNT, postId);
            return list;
        }

        public List<Post> GetRecentPosts(int threadId)
        {
            List<Post> list = __postRepos.Read(threadId, Constants.POST_GROUP_COUNT);
            return list;
        }

        public List<Post> GetRecentPosts()
        {
            List<Post> list = __postRepos.ReadRecent();
            return list;
        }

        #region private

        private string Strip(string source)
        {
            if (source.ToUpper().Contains("HTTP:") || source.ToUpper().Contains("WWW."))
            {
                return string.Empty;
            }

            string s = Regex.Replace(source, @"[^\p{L}\p{N}]+", string.Empty);

            return s.ToUpper();
        }

        #endregion
    }
}
