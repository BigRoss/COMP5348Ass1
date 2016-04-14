using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Business.Entities
{
    public partial class Like
    {
        public Recommendation findRec()
        {
            Dictionary<Media, int> likeMap = new Dictionary<Media, int>();
            Media x = this.Media;
            //Find all likes on x
            foreach (Like likeonmedia in x.Likes)
            {
                //Get the other users who liked x
                User u = likeonmedia.User;
                //ignore current user
                if (!u.Equals(this.User))
                {
                    //get all the likes on other media
                    foreach(Like otherlike in u.Likes){
                        int numLikes = 0;
                        if (likeMap.TryGetValue(otherlike.Media, out numLikes))
                        {
                            numLikes++;
                            likeMap[otherlike.Media] = numLikes;
                        }
                        else 
                        {
                            likeMap.Add(otherlike.Media, 1);
                        }
                    }
                }
            }
            Media mostLiked = null;
            int maxScore = 0;
            foreach (KeyValuePair<Media,int> entry in likeMap) {
                if (entry.Value > maxScore) 
                {
                    mostLiked = entry.Key;
                    maxScore = entry.Value;
                }
            }
            
            Recommendation rec = new Recommendation();
           
            rec.Like = this;
            rec.Score = maxScore;
            rec.Media = mostLiked;
            return rec;

        }
        
    }
}
/**
 * //Get all the likes from this user
            foreach (Like like in this.Likes)
            {
                //get all the liked media 
                Media likedmedia = like.Media;
                //get all the likes on that media
                foreach (Like l in likedmedia.Likes) {
                    //get all the users that liked similar media items
                    User u = l.User;
                    //get all the likes on those users
                    foreach (Like l2 in u.Likes)
                    {
                        bool recfound = false;
                        //to exclude the current users likes in rec
                        if (!u.Equals(this))
                        {
                            //find the reccomendation on that item and increase the score
                            foreach (Recommendation rec in l2.Recommendations)
                            {
                                if (rec.Media.Equals(l.Media)) {
                                    recfound = true;
                                    rec.Score++;
                                }
                            }
                        }
                        // if rec not found create rec
                        if (recfound == false) {
                            Recommendation rec = new Recommendation()
                        }
                    }
                }
            }
*/