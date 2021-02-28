﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Contract_Employee_Payments_Core_App.BusinessLayer;
using Contract_Employee_Payments_Core_App.Models;

namespace Contract_Employee_Payments_Core_App.Pages.TimeRecords
{
    public class IndexModel : PageModel
    {
        private readonly Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext _context;

        public IndexModel(Contract_Employee_Payments_Core_App.Models.Contract_Employee_PaymentsDataContext context)
        {
            _context = context;
        }

        public IList<TimeRecord> TimeRecord { get;set; }

        public async Task OnGetAsync()
        {
            TimeRecord = await _context.TimeRecord
                .Include(t => t.ContractEmployee)
                .Include(t => t.Project).ToListAsync();
        }
    }
}
