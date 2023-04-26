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

  [UseDbContext(typeof(AppDbContext))]
  public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
  {
    return context.Commands;
  }
}