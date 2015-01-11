using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace KamTu.Models
{
    public class KamtuRepository : IKamtu
    {
        KamTuDB db = new KamTuDB();

        public List<Driver> dameDriversDeUnOrigen(string origen)
        {
            Debug.WriteLine("en repo");
            var resultados = (from c in db.Drivers
                            where c.Origin==origen
                            select c).ToList();

            Debug.WriteLine("{0}",resultados.Count);
            Debug.WriteLine("{0}", origen);
            foreach (var resultado in resultados)
            {

                Debug.WriteLine("{0}",resultado.Name);
            }
            return resultados.ToList();
        }

    }
}