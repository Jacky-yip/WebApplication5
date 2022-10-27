using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace WebApplication5.Entities
{
    public class tb1
    {
        public int id { get; set; }
        public string machineId { get; set; }
        public decimal value { get; set; }
        public DateTime createDate { get; set; }

    }
}
