﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIUREA_COSMIN_LAB2.Data;
using CIUREA_COSMIN_LAB2.Models;

namespace CIUREA_COSMIN_LAB2.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly CIUREA_COSMIN_LAB2.Data.CIUREA_COSMIN_LAB2Context _context;

        public DetailsModel(CIUREA_COSMIN_LAB2.Data.CIUREA_COSMIN_LAB2Context context)
        {
            _context = context;
        }

      public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Category == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else 
            {
                Category = category;
            }
            return Page();
        }
    }
}
