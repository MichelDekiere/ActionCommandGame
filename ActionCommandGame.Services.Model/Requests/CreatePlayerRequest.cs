using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionCommandGame.Services.Model.Requests
{
    public class CreatePlayerRequest
    {
        [DisplayName("Player Name")]
        public string Name { get; set; }

    }
}
