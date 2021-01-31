using LAB1Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LAB1Prueba.Controllers
{
    public class ValuesController : ApiController
    {
        double resultadoOp = 0;

        // GET api/values
        public IHttpActionResult GetOperacion([FromBody] string json)
        {
            Operacion oper;
            if (json == null)
            {
                return NotFound();
            } else
            {
                oper = Newtonsoft.Json.JsonConvert.DeserializeObject<Operacion>(json);
            }
            return Ok(Procesar(oper));
        }


        // POST api/values
        [HttpPost]
        public async System.Threading.Tasks.Task<string> Post(HttpRequestMessage request)
        {
            string body = await request.Content.ReadAsStringAsync();
            Operacion op = Newtonsoft.Json.JsonConvert.DeserializeObject<Operacion>(body);
            return Procesar(op).ToString();
        }
       
        private double Procesar(Operacion operacion)
        {
            if (operacion.tipoOperacion.Equals("Suma"))
            {
                return operacion.valor1 + operacion.valor2;
            }
            else if (operacion.tipoOperacion.Equals("Resta"))
            {
                return operacion.valor1 - operacion.valor2;
            }
            else if (operacion.tipoOperacion.Equals("Multiplicacion"))
            {
                return operacion.valor1 * operacion.valor2;
            }
            else
                return operacion.valor1 / operacion.valor2;
            }
        }
    }
