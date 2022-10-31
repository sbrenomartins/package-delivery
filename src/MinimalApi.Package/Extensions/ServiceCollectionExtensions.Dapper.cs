﻿using System.Data.SqlClient;

namespace MinimalApi.Package.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddDapper(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped(_ => new SqlConnection(
                    builder.Configuration.GetConnectionString("SQL")
                 ));

            return builder;
        }
    }
}
