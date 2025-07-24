using System;
using System.Collections.Generic;
using System.Linq;

namespace HigLabo.Core;

public static class PagingList
{
    public static int GetMaxPageIndex(int totalRecordCount, int recordCountPerPage)
    {
        if (totalRecordCount <= recordCountPerPage)
        {
            return 0;
        }
        else
        {
            var remain = totalRecordCount % recordCountPerPage;
            var quotient = totalRecordCount / recordCountPerPage;
            if (remain == 0)
            {
                return quotient - 1;
            }
            else
            {
                return quotient;
            }
        }
    }
    public static int GetMaxPageNumber(int totalRecordCount, int recordCountPerPage)
    {
        return GetMaxPageIndex(totalRecordCount, recordCountPerPage) + 1;
    }
}
public class PagingList<T> : List<T>
{
    public int TotalRecordCount { get; set; }
}

public static class PagingListExtensions
{
    public static int GetMaxPageIndex<T>(this PagingList<T> pageingList, int recordCountPerPage)
    {
        return PagingList.GetMaxPageIndex(pageingList.TotalRecordCount, recordCountPerPage);
    }
    public static int GetMaxPageNumber<T>(this PagingList<T> pageingList, int recordCountPerPage)
    {
        return PagingList.GetMaxPageIndex(pageingList.TotalRecordCount, recordCountPerPage) + 1;
    }
}
