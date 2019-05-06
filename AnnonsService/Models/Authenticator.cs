using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnonsService.Models
{
    public class Authenticator
    {
        public int GetUserId()
        {
            int UserId = 1;
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