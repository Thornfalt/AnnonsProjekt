﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnonsService.Models
{
    public class Authenticator
    {
        // hämta användar-id från annan service 
        public int GetUserId(int UserId)
        {
            
            return UserId;
        }
        public bool IsAllowed(int userId, int serviceCreatorId, string right)
        {
            if (userId == serviceCreatorId)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}