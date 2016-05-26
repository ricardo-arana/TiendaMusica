using Insight.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.InsightDB
{
    public class AlbumGenericRepository : IGenericRepository<Album>
    {
        private readonly IDbConnection db;
        public AlbumGenericRepository(IDbConnection db)
        {
            this.db = db;
        }
        public IEnumerable<Album> Get(string query, object parameters)
        {
            return db.Query<Album>(query, parameters);
        }


        public void Add(Album entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Album entity)
        {
            throw new NotImplementedException();
        }



        public IQueryable<Album> Find(Expression<Func<Album, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Album First(Expression<Func<Album, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    

        public IQueryable<Album> GetAll()
        {
            throw new NotImplementedException();
        }

        public Album Single(Expression<Func<Album, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Album SingleOrDefault(Expression<Func<Album, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Album entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> ConsultaAdHoc(string query, object parameters)
        {
            return db.Query<Album>(query, parameters);
        }
    }
}
