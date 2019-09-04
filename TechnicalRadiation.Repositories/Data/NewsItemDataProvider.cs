using System;
using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Repositories.Data
{
    public class NewsItemDataProvider
    {
        private static readonly string _adminName = "TechnicalRadiationAdmin";

        public static List<NewsItem> NewsItems = new List<NewsItem>
        {
            new NewsItem {

                Id = 1,
                Title = "Petra goes nuts",
                ImgSource = "https://tmbidigitalassetsazure.blob.core.windows.net/secure/RMS/attachments/37/1200x1200/Cobb-Salad-Club-Sandwich_EXPS_THAM19_233459_B11_09_2b.jpg",
                ShortDescription = "Petra totally lost it and is not OK!",
                LongDescription = "This after noon, Petra a 27 years old women totally lost it. She did not get the sandwich that she wanted and is now throwing tables and can bottles in Reykjavík University.",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ModifiedBy = _adminName
            }
        };
    }
}