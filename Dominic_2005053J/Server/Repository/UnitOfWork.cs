using Dominic_2005053J.Server.Data;
using Dominic_2005053J.Server.IRepository;
using Dominic_2005053J.Server.Models;
using Dominic_2005053J.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Dominic_2005053J.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Severity> _severitys;
        private IGenericRepository<Symptom> _symptoms;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Severity> Severitys
            => _severitys ??= new GenericRepository<Severity>(_context);
        public IGenericRepository<Symptom> Symptoms
            => _symptoms ??= new GenericRepository<Symptom>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseModel)entry.Entity).CreatedDate = DateTime.Now;
                ((BaseModel)entry.Entity).CreatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseModel)entry.Entity).CreatedDate = DateTime.Now;
                    ((BaseModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
