using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Models
{
    public class NewsMaker
    {
        private List<NewsModel> _list { get; set; }

        public NewsMaker()
        {
            _list = new List<NewsModel>()
            {
                new NewsModel()
                {
                    Tittle = @"C# : The New and Improved C# 6.0",
                    Content = @"Although C# 6.0 isn’t yet complete, it’s at a point now where the features are close to being 
                                finalized. There have been a number of changes and improvements made to C# 6.0 in the CTP3 release 
                                of the next version of Visual Studio, code-named “14,” since the May 2014 article, “A C# 6.0 Language 
                                Preview” (msdn.microsoft.com/magazine/dn683793.aspx).In this article, I’ll introduce the new features 
                                and provide an update on the features discussed back in May. I’ll also maintain a comprehensive up-to-date 
                                blog describing updates to each C# 6.0 feature. Check it out at intellitect.com/EssentialCSharp/. Many of 
                                these examples are from the next edition of my book, “Essential C# 6.0” (Addison-Wesley Professional)."
                },
                new NewsModel()
                {
                    Tittle = @"On the Market: New build in Stratfield section of town",
                    Content = @"In recent years many Realtors are adding the talent of staging to their resumes, an expertise that Realtor 
                            Debra Kandrak has practiced for 30 years. She has taken it to the next level in the newly constructed colonial 
                            house at 10 Jackman Ave. in the Stratfield neighborhood not only staging the house but working with the builder 
                            to recommend some of this home’s key components including its layout. In most rooms she has even shopped for and 
                            selected light fixtures, the high-end imported kitchen appliances, bathroom faucets, and hardware."
                },
                new NewsModel()
                {
                    Tittle = @"A Lincoln Pops New Year's Eve",
                    Content = @"A 16 year old belting out tunes on a trombone alongside an 85 year old may not be an everyday sight, but it’s not uncommon.
                            Once a month, the Lincoln Pops Orchestra brings talented local high school students and professionals of all ages together to 
                            play big band music.“This year went very well,” said Amanda Berks, who does public relations for the band. “We all have great fun. 
                            The people who come always seem to enjoy themselves. We would like to get more locals to come, though.”"
                }
            };
        }

        public IEnumerable<NewsModel> GetNews()
        {
            return _list;
        }
        public IEnumerable<NewsModel> AddNews(IEnumerable<NewsModel> news)
        {
            _list.AddRange(news);
            return _list;
        }
    }
}