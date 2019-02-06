using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace NorthWind.DAL
{
    class NorthWindModelCacheFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            var NorthWindContext = context as NorthWindContext;
            return (context.GetType(), NorthWindContext.IgnoreDescriptionAndImage);
        }
    }
}
