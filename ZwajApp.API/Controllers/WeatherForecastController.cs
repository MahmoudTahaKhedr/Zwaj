﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZwajApp.API.Data;

namespace ZwajApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            _context=context;
        }
        

       

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
           var Values=await _context.Values.ToListAsync();
           return Ok(Values);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
           var Value=await _context.Values.FirstOrDefaultAsync(x=>x.id==id);
           return Ok(Value);

        }
    }
}
