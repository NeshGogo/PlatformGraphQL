using PlatformGQL.Data;
using PlatformGQL.Models;

namespace PlatformGQL.GraphQL;
public class Query
{
  [UseDbContext(typeof(AppDbContext))]
  public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
  {
    return context.Platforms;
  }
}