using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_AaronHernandez.DAL;
using Parcial1_AP1_AaronHernandez.Models;
using System.Linq.Expressions;

namespace Parcial1_AP1_AaronHernandez.Services
{
    public class MetasService
    {
        private readonly Contexto _contexto;
        public MetasService(Contexto contexto) 
        {
            _contexto = contexto;
        }


        public async Task<bool> Existe(int MetaID)
        {
            return await _contexto.Metas!.AnyAsync(m => m.MetaId == MetaID);
        }

        public async Task<bool> Insertar(Metas meta)
        {
            _contexto.Add(meta);
            return await _contexto.SaveChangesAsync() > 0;
        }

		public async Task<bool> Modificar(Metas meta)
		{
			_contexto.Update(meta);
			var guardado = await _contexto.SaveChangesAsync() > 0;
			_contexto.Metas!.Entry(meta).State = EntityState.Detached;
			return guardado;
		}

		public async Task<bool> Eliminar(Metas meta)
		{
			return await _contexto.Metas!.AsNoTracking().Where(m => m.MetaId == meta.MetaId).ExecuteDeleteAsync() > 0;
		}

		public async Task<Metas?> Buscar(Metas meta)
		{
			return await _contexto.Metas!.AsNoTracking().FirstOrDefaultAsync(m => m.MetaId == meta.MetaId);
		}

		public async Task<List<Metas>> Listar(Expression<Func<Metas, bool>> criterio)
		{
			return await _contexto.Metas!.AsNoTracking().Where(criterio).ToListAsync();
		}

		public async Task<bool> Guardar(Metas meta)
		{
			if (await Existe(meta.MetaId))
			{
				return await Modificar(meta);
			}
			else
			{
				return await Insertar(meta);
			}
		}

	}
}
