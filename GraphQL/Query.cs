using PlatformGQL.Data;
using PlatformGQL.Models;

namespace PlatformGQL.GraphQL;
public class Query
{
  [UseDbContext(typeof(AppDbContext))]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Platform> GetPlatforms([ScopedService] AppDbContext context)
  {
    return context.Platforms;
  }

  [UseDbContext(typeof(AppDbContext))]
  [UseFiltering]
  [UseSorting]
  public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
  {
    return context.Commands;
  }
}