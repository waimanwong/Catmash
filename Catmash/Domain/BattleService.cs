using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catmash.Domain
{

    public class BattleService : IBattleService
    {
        public NewBattleDto InitBattle()
        {
            return new NewBattleDto
            {
                Images = new List<ImageDto>()
                {
                    new ImageDto { Id = "foo", Url = "url1"},
                    new ImageDto { Id = "bar", Url = "bar"}
                }
            };
        }
    }

}
