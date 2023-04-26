using PlatformGQL.Data;
using PlatformGQL.Models;

namespace PlatformGQL.GraphQL.Commands;

public class CommandType : ObjectType<Command>
{
  protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
  {
    descriptor.Description("Represents any executable command");

    descriptor.Field(p => p.Platform)
    .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default!))
    .UseDbContext<AppDbContext>()
    .Description("This is the platform to which the command belongs");

  }

  private class Resolvers
  {
    public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context){
      return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
    }
  }
}