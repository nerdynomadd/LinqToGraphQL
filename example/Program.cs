﻿using System;
using System.Collections.Generic;
using System.Linq;
using LinqToGraphQL.Extensions;
using TestClient.User;

namespace TestClient
{
	class Program
	{
		static void Main(string[] args)
		{
			using var userContext = new UserContext();


			IQueryable<User.User> userQuery2 = userContext.GetUser(new UserInput
			{
				Name = "test",
				Description = "est"
			})
				.Select(e => new User.User
				{
					Name = e.Name,
					Username = e.Username
				})
				.Include(e => e.Posts(1));

			/**
			 * IQueryable<User.User> userQuery = userContext.GetUser( new UserInput
				{
					Name = "test",
					Description = "est"
				})
				.Select(e => new User.User
				{
					Name = e.Name,
					Username = e.Username
				})
				.Include(e => e.Posts(10))
					.Select(e => new Post.Post()
					{
						Content = e.Content,
						Title = e.Title
					})
					.ThenInclude(e => e.Comments(10))
						.Select(e => new Comment.Comment
						{
							Content = e.Content,
							Title = e.Title
						});
			 */
			
			for (var x = 0; x <= 10; x++)
			{
				try
				{
					Console.WriteLine(userQuery2.ToItem());
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}

			// var user = userQuery.ToItem();
			
			//Console.WriteLine(user);
		}
	}
}