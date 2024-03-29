﻿using System.Linq;
using System.Net.Http;

namespace LinqToGraphQL.Set.Configuration.Builder
{
	public class GraphSetExistingConfigurationBuilder : GraphSetConfigurationBuilder
	{
		private readonly GraphSetConfiguration _graphSetConfiguration;
		
		public GraphSetExistingConfigurationBuilder(GraphSetConfiguration graphSetConfiguration)
		{
			_graphSetConfiguration = graphSetConfiguration;
		}
		
		internal override GraphSetConfiguration Build()
		{
			var graphSetHttpConfiguration = HttpConfigurationBuilder.Build();

			var graphSetQueryConfiguration = QueryConfigurationBuilder.Build();

			if (!string.IsNullOrEmpty(Url) && _graphSetConfiguration.Url != Url)
			{
				_graphSetConfiguration.Url = Url;

				_graphSetConfiguration.Http.RequestUri = Url;
			}

			if (graphSetHttpConfiguration.Headers.Any())
			{
				foreach (var header in graphSetHttpConfiguration.Headers)
				{
					_graphSetConfiguration.Http.Headers.Add(header.Key, header.Value);
				}
			}

			if (graphSetHttpConfiguration.Method is null && _graphSetConfiguration.Http.Method is null)
			{
				_graphSetConfiguration.Http.Method = HttpMethod.Get;
			} else if (graphSetHttpConfiguration.Method is not null && graphSetHttpConfiguration.Method != _graphSetConfiguration.Http.Method)
			{
				_graphSetConfiguration.Http.Method = graphSetHttpConfiguration.Method;
			}
			
			// Query configuration
			if (graphSetQueryConfiguration.Type != _graphSetConfiguration.Query.Type)
			{
				_graphSetConfiguration.Query.Type = graphSetQueryConfiguration.Type;
			}
 			
			return _graphSetConfiguration;
		}
	}
}