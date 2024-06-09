using System.Reflection.Metadata;
using Core.Entity;
using EF_Assign1;
using Microsoft.EntityFrameworkCore;


public class Program
{
    public static void Main(string[] args)
    {
        var dbContext = new BloggingContext();
        dbContext.Database.EnsureCreated();
        var user1 = new User
        {
            Name = "SK",
            EmailAddress = "SK@gmail.com",
            PhoneNumber = "555-876-9988"
        };
        var user2 = new User
        {
            Name = "MK",
            EmailAddress = "MK@gmail.com",
            PhoneNumber = "777-555-3344"
        };
        var user3 = new User
        {
            Name = "OK",
            EmailAddress = "OK@gmail.com",
            PhoneNumber = "987-333-1122"
        };
        dbContext.Users.Add(user1);
        dbContext.Users.Add(user2);
        dbContext.Users.Add(user3);
        dbContext.SaveChanges();


        var postType = new PostType
        {
            Status = Core.Constant.Active,
            Name = "Nail Art",
            Description = "Post of nail art"
        };

        var blogType = new BlogType
        {
            Status = Core.Constant.Active,
            Name = "Make-up",
            Description = "Make-up Blog"
        };
        dbContext.PostTypes.Add(postType);
        dbContext.BlogTypes.Add(blogType);
        dbContext.SaveChanges();


        var blog_Type = dbContext.BlogTypes.FirstOrDefault();
        dbContext.Blogs.Add(new Blog()
        {
            IsPublic = true,
            Url = "Sky.com",
            BlogTypeId = blog_Type.BlogTypeId
        });
        dbContext.SaveChanges();

        var user = dbContext.Users.FirstOrDefault();
        var blog = dbContext.Blogs.FirstOrDefault();
        var post_Type = dbContext.PostTypes.FirstOrDefault();


        var post = new Post()
        {
            Title = "New Nail Art",
            Content = "New Nail Art Description.",
            BlogId = blog.BlogTypeId,
            PostTypeId = post_Type.PostTypeId,
            UserId = user.UserId
        };
        dbContext.Posts.Add(post);
        dbContext.SaveChanges();


        var users = dbContext.Users.ToList();
        Console.WriteLine("User Details");
        foreach (var u in users)
        {
            Console.WriteLine($"ID: {u.UserId}, Name: {u.Name}, Email: {u.EmailAddress}, Phone: {u.PhoneNumber}");
        }

        var BlogTypes = dbContext.BlogTypes.ToList();
        Console.WriteLine("Blog Type Details");
        foreach (var BlogType in BlogTypes)
        {
            Console.WriteLine($"ID: {BlogType.BlogTypeId}, Status: {BlogType.Status}, Name: {BlogType.Name}, Description: {BlogType.Description}");
        }

        var PostTypes = dbContext.PostTypes.ToList();
        Console.WriteLine("Post Type Details");
        foreach (var PostType in PostTypes)
        {
            Console.WriteLine($"ID: {PostType.PostTypeId}, Status: {PostType.Status}, Name: {PostType.Name}, Description: {PostType.Description}");
        }

        var Blogs = dbContext.Blogs.ToList();
        Console.WriteLine("Blog Details");
        foreach (var Blog in Blogs)
        {
            Console.WriteLine($"ID: {Blog.BlogId}, Url: {Blog.Url}, Status: {Blog.IsPublic}, BlogTypeId: {Blog.BlogTypeId}");
        }

        var posts = dbContext.Posts.ToList();
        Console.WriteLine("Post Details");
        foreach (var p in posts)
        {
            Console.WriteLine($"ID: {p.PostId}, Title: {p.Title}, Content: {p.Content}, BlogId: {p.BlogId}, PostTypeId: {p.PostTypeId}, UserId: {p.UserId}");
        }


    }
}
