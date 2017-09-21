using MusicLibrary.Domain.Entities;
using MusicLibrary.Domain.Models;
using NHibernate;

namespace MusicLibrary.Dal.Utils
{
    public static class PagingExtension
    {
        public static IQueryOver<T> Paginate<T, TSub>(this IQueryOver<T, TSub> query, PageData pageData) where T:Entity
        {
            return query.Skip((pageData.Page - 1) * pageData.PageSize)
                .Take(pageData.PageSize);
        }
    }
}