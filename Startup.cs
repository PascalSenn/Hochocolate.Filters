using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace filtersplayground
{
    public class Startup
    {
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			// If you need dependency injection with your query object add your query type as a services.
			// services.AddSingleton<Query>();

			// enable InMemory messaging services for subscription support.
			// services.AddInMemorySubscriptionProvider();

			// this enables you to use DataLoader in your resolvers.
			services.AddDataLoaderRegistry();

			// Add GraphQL Services
			services.AddGraphQL(sp => Schema.Create(c =>
			{
				// enable for authorization support
				// c.RegisterAuthorizeDirectiveType();
				c.RegisterQueryType<TestQueryType>();
			}));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// enable this if you want tu support subscription.
			// app.UseWebSockets();
			app.UseGraphQL();
			// enable this if you want to use graphiql instead of playground.
			// app.UseGraphiQL();
			app.UsePlayground();
		}
	}
}
