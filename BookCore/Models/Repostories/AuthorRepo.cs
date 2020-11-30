using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCore.Models.Repostories
{
    public class AuthorRepo : IBookstoreRepostory<Auther>
    {
        List<Auther> authers;

        public AuthorRepo()
        {
           authers = new List<Auther>()
            {
                new Auther
                {
                    Id=1,FullName="ahmd"
                },
                 new Auther
                {
                    Id=2,FullName="heba"
                }
            };
        }
        public void Add(Auther entity)
        {
            authers.Add(entity);
            
        }

        public void Delete(int id)
        {
            var auther = Find(id);
            authers.Remove(auther);
        }

        public Auther Find(int id)
        {
            var author = authers.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public IList<Auther> List()
        {
            return authers;
        }

        public void Update(int id, Auther newAuther)
        {
            var author = Find(id);
            author.FullName = newAuther.FullName;
        }
    }
}
