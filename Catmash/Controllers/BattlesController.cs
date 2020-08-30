using Catmash.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Controllers
{
    
    [ApiController]
    public class BattlesController
    {
        private IBattleService _battleService;

        public BattlesController(IBattleService battleService)
        {
            _battleService = battleService;
        }

        [HttpGet]
        [Route("battles/init")]
        public Task<NewBattleDto> GetNewBattleAsync()
        {
            return _battleService.InitBattleAsync();
        }

        [HttpPost]
        [Route("battles/outcomeRegistration")]
        public Task RegisterBattleOutcome(BattleOutcomeDto battleOutcomeDto)
        {
            return _battleService.RegisterBattleOutcomeAsync(battleOutcomeDto);
        }


    }
}
