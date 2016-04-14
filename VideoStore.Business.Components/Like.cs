using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Business.Components.Interfaces;
using VideoStore.Business.Entities;
using System.Transactions;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace VideoStore.Business.Components
{
    public class Like : ILikeProvider
    {
        public void createLike(VideoStore.Business.Entities.Like like)
        {
            using (TransactionScope lScope = new TransactionScope())
            using (VideoStoreEntityModelContainer lContainer = new VideoStoreEntityModelContainer())
            {
                lContainer.Likes.Add(like);
                lContainer.SaveChanges();
                lScope.Complete();
            }
        }
    }
}
