using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;
using System.Transactions;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace VideoStore.Business.Components
{
    public class Recommendation : IRecommendationProvider
    {
        public void CreateRecommendation(VideoStore.Business.Entities.Recommendation rec)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Recommendations.Add(rec);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }
    }
}
