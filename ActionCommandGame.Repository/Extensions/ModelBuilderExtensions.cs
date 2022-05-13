using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ActionCommandGame.Repository.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (tableName is not null && tableName.ToLowerInvariant().StartsWith("aspnet"))
                {
                    continue;
                }

                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
