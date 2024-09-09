﻿using Hexa_Hub.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hexa_Hub.Repository
{
    public class AuditRepo : IAuditRepo
    {
        private readonly DataContext _context;

        public AuditRepo(DataContext context)
        {
            _context = context;
        }
        public async Task AddAuditReq(Audit audit)
        {
            _context.Audits.Add(audit);
        }

        public async Task DeleteAuditReq(int id)
        {
            var aId = await _context.Audits.FindAsync(id);
            if(aId == null)
            {
                throw new Exception("Audit Not Found");
            }
            _context.Audits.Remove(aId);
        }

        public async Task<List<Audit>> GetAllAudits()
        {
            return await _context.Audits
                .ToListAsync();
        }

        public async Task<Audit?> GetAuditById(int id)
        {
            return await _context.Audits.FirstOrDefaultAsync(a=>a.AuditId == id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task<Audit> UpdateAudit(Audit audit)
        {
            _context.Audits.Update(audit);
            return Task.FromResult(audit);
        }
    }
}
