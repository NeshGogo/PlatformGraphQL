using PlatformGQL.Data;
using PlatformGQL.Models;

namespace PlatformGQL.GraphQL;
public class Query
{
  public IQueryable<Platform> GetPlatforms([Service] AppDbContext context)
  {
    return context.Platforms;
  }
}