using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApiGraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGraphQL.Queries;
using WebApiGraphQL.Mutations;

namespace WebApiGraphQL
{
    public class BlogSchema : Schema
    {
        public BlogSchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<BlogQuery>();
            Mutation = serviceProvider.GetRequiredService<BlogMutation>();
        }
    }
}
