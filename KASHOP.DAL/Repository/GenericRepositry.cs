using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Repository
{
    public class GenericRepositry<T>:IGenericRepository<T> where T:class
    {


        private readonly ApplicationDbContext _context;
        public GenericRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
         await   _context.SaveChangesAsync();
            return entity;
        }

       
        public async Task<List<T>> GetAllAsync()
        {
            return  await _context.Set<T>().ToListAsync();
            //    var response = _context.Adapt<List<CategoryResponse>>();
            //}
        }
    }
}

