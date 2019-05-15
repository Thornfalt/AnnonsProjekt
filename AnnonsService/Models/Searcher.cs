using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnnonsService.Models
{
    public class Searcher
    {
        public bool ObjectSearch(ServiceData serviceToSearch, SearchService searchService)
        {
            /*
             * För varje attribut:
             *  if != null osv
             *  if värde != sökvärde return false
             *  
             *  else return true
             */
             if (searchService.Title != null)
            {
                if (!SearchInString(serviceToSearch.Title, searchService.Title))
                {
                    return false;
                }
            }
            if (searchService.Description != null)
            {
                if (!SearchInString(serviceToSearch.Description, searchService.Description))
                {
                    return false;
                }
            }
            if (searchService.CreatorID > 0)
            {
                if (serviceToSearch.CreatorID != searchService.CreatorID)
                {
                    return false;
                }
            }
            if (searchService.Price != null)
            {
                if (searchService.Price.Max > 0 && serviceToSearch.Price > searchService.Price.Max)
                {
                    return false;
                }

                if (searchService.Price.Min > serviceToSearch.Price)
                {
                    return false;
                }
               
            }
            if (searchService.CreatedTime != null)
            {
                if (!SearchByDateRange(searchService.CreatedTime, serviceToSearch.CreatedTime))
                {
                    return false;
                }
            }

            if (searchService.StartDate != null)
            {
                if (!SearchByDateRange(searchService.StartDate, serviceToSearch.StartDate))
                {
                    return false;
                }
            }

            if (searchService.EndDate != null)
            {
                if (!SearchByDateRange(searchService.EndDate, serviceToSearch.EndDate))
                {
                    return false;
                }
            }
            if (searchService.ServiceStatusId > 0) // TODO: Naiv sökning. Tar ej hänsyn till to & from-date.
            {
                if (searchService.ServiceStatusId != serviceToSearch.ServiceStatusData.ServiceStatusTypeData.Id)
                {
                    return false;
                }
            }
            if (searchService.ServiceTypeIds.Count > 0)
            {
                if (!searchService.ServiceTypeIds.Contains(serviceToSearch.ServiceTypeData.Id))
                {
                    return false;
                }
            }
            if (searchService.SubCategoryIds.Count > 0)
            {
                if (!searchService.SubCategoryIds.Contains(serviceToSearch.SubCategoryData.Id))
                {
                    return false;
                }
            }

            return true;
        }

        private bool SearchInString(string stringToSearch, string searchValue)
        {
            return stringToSearch.ToLower().Contains(searchValue.ToLower());
        }


        public bool SearchInDatabase(string searchTitle, string searchDescription, string searchSubCategory, string searchCategory, string searchValue)
        {
            if (SearchInString(searchTitle, searchValue) ||
            SearchInString(searchDescription, searchValue) ||
            SearchInString(searchSubCategory, searchValue) ||
            SearchInString(searchCategory, searchValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool SearchByDateRange(DateRange dateRange, DateTime? givenDate)
        {
            // Checks if givenDate is within the DateRange
            if (dateRange.Start != null)
            {
                if (givenDate < dateRange.Start)
                {
                    return false;
                }
            }

            if (dateRange.End != null)
            {
                if (givenDate > dateRange.End)
                {
                    return false;
                }
            }

            return true;
        }
    }
}