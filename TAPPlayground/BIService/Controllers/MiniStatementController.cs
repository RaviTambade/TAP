using System.Collections.Generic;
using BIService.Models;
using BIService.Services;
using BIService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BIService.Controllers
{
   [ApiController]
    [Route("/api/[controller]")]
    public class MiniStatementController : ControllerBase

    {
        private readonly IMiniStatementService _MSsrv;
        public MiniStatementController(IMiniStatementService MSsrv)
        {
            _MSsrv = MSsrv;
        }

        [HttpGet]
        [Route("/getMiniStatements/{id}")]
        public IEnumerable<MiniStatement> GetMiniStatements(int id)
        {
            List<MiniStatement> miniStatement = _MSsrv.GetMiniStatement(id);
            return miniStatement;
        }
    }
}

