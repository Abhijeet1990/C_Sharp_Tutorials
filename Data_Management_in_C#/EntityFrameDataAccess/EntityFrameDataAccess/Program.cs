using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();
                //Console.WriteLine("enter a post title for a new post");
                //var title = Console.ReadLine();
                Console.WriteLine("enter user name");
                var uname = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                //var post = new Post { Title = title };
                //db.Posts.Add(post);
                //db.SaveChanges();

                var user = new User { UserName = uname };
                db.Users.Add(user);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public virtual List<Post> Posts { get; set; }
        //use of the virtual keyword  is to modify the inherited property..in the child classes
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Blogid { get; set; }
        public virtual Blog blog { get; set; }
    }

    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string DisplayName { get; set; }

    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.DisplayName).HasColumnName("display_name");
        }
    }

}
