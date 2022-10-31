using Dapper;
using MassTransit;
using System.Data.SqlClient;

namespace MinimalApi.Package.Modules
{
    public class PackageModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/package", async (SqlConnection db) =>
                await db.QueryAsync("select * from package"));

            app.MapGet("/package/{code}", async (SqlConnection db, string code) =>
                await db.QueryFirstAsync("select * from package where code = @code", new { code }));

            app.MapPost("/package", async (SqlConnection db, RegisterPackageDto dto, IPublishEndpoint publish) =>
            {
                var newPackage = await db.QueryFirstOrDefaultAsync<RegisterPackageDto>
                (
                    @"insert into package(code, country, description)
                      output inserted.*
                      values(@code, @country, @description)", dto
                );

                await publish.Publish(new PackageCreated()
                {
                    PackageId = newPackage.PackageId,
                    Code = newPackage.Code,
                    TimeStamp = DateTimeOffset.Now
                });

                return Results.Created($"/package/{newPackage.PackageId}", newPackage);
            });
        }
    }
}
