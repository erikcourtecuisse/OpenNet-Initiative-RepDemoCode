﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projet.EmploiDuTemps.Data;
using Projet.EmploiDuTemps.Models;

namespace Projet.EmploiDuTemps.Pages.UEs
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Projet.EmploiDuTemps.Data.ApplicationDbContext _context;

        public DetailsModel(Projet.EmploiDuTemps.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UE UE { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UE = await _context.UE.FirstOrDefaultAsync(m => m.ID == id);

            if (UE == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
