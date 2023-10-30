using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Contracts
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CratedAt { get; set; }
    }
}
