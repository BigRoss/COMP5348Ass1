﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components.Interfaces
{
    public interface ILikeProvider
    {
        void CreateLike(Like like);
    }
}
