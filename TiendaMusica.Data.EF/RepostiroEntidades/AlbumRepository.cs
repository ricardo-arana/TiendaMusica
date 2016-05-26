using TiendaMusica.Data.Repositorio.EF;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.EF.RepostiroEntidades
{

    public class AlbumRepository : GenericRepository<EFTiendaMusicaRepository, Album>
    {
        public AlbumRepository(EFTiendaMusicaRepository contexto):base(contexto)
        {

        }
    }
}
