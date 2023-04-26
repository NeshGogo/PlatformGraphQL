using PlatformGQL.Data;
using PlatformGQL.GraphQL.Commands;
using PlatformGQL.GraphQL.Platforms;
using PlatformGQL.Models;

namespace PlatformGQL.GraphQL;
public class Mutations
{
  [UseDbContext(typeof(AppDbContext))]
  public async Task<AddPlatformPayload> AddPlaformAsync(AddPlatformInput input, [ScopedService] AppDbContext context)
  {
    var platform = new Platform{
      Name = input.Name,
    };

    context.Add(platform);
    await context.SaveChangesAsync();

    return new AddPlatformPayload(platform);
  }

  [UseDbContext(typeof(AppDbContext))]
  public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, [ScopedService] AppDbContext context)
  {
    var command = new Command{
      HowTo = input.HowTo,
      PlatformId = input.PlatformId,
      CommandLine = input.CommandLine,
    };

    context.Add(command);
    await context.SaveChangesAsync();

    return new AddCommandPayload(command);
  }
}